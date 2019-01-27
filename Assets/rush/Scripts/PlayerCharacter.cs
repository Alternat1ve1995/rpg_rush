using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCharacter : Character
{
    private Coroutine attackingCoroutine;

    private IEnumerator Start()
    {
        
        yield return null;
        hud.ToggleActive(true);
       

    }

    private void Update()
    {
        if (hp <= 0 && !isDead)
            Die();

        if (Input.GetMouseButtonDown(0))
        {
            SetMoveTarget();
        }

        AnimateCharacter();
    }

    public void LeveUp()
    {
        stats.SetLevel(stats.lvl + 5);
        hp = stats.maxHP;
        exp = exp - stats.xpToNext;
        if (exp < 0) exp = 0;
        if (lvlupPrefab != null)
            Instantiate(lvlupPrefab, transform.position + Vector3.up, Quaternion.identity, transform);
    }
    
    void SetMoveTarget()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(camRay, out hit, 10000, EnemyMask))
        {

            target = hit.collider.GetComponent<Character>();
            if (target != null)
            {
                Move(hit);
                attackingCoroutine = StartCoroutine(Attacking());
                target.hud.ToggleActive(true);
            }
            
            return;
        }

        if (Physics.Raycast (camRay, out hit, 10000, FloorMask))
        {
            _debugPoint = hit.point;
            if (target != null)
                target.hud.ToggleActive(false);
            target = null;
            if (attackingCoroutine != null)
                StopCoroutine(attackingCoroutine);
            Move(hit);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Potion")
        {
            Destroy(other.gameObject);
            Heal();
            
        }
    }

    void Heal()
    {
        hp += (int)(stats.maxHP * 0.15f);
    }
    

    float GetDamage()
    {
        return CalculateDamage(stats, target.stats);
    }
    

    IEnumerator Attacking()
    {
        transform.LookAt(target.transform);
        while (target != null)
        {
            transform.LookAt(target.transform);
            if (HowNear(transform, target.transform) <= attackRange)
            {
               
                animator.SetTrigger("Attack");
                yield return new WaitForSeconds(0.2f);
                float damage = GetDamage();
//                Debug.Log(damage);
                target.TakeDamage(damage);
            }
            if (target.hp <= 0)
                break;
            yield return null;
        }
        
    }

    
    
    private void Move(RaycastHit hit)
    {
        CalculateAndSetPath(hit.point);
    }
    
    private void CalculateAndSetPath(Vector3 destination)
    {
        NavMeshPath path = new NavMeshPath();
        NavMeshHit hit;
        
        if (NavMesh.SamplePosition(destination, out hit, 20, NavMesh.AllAreas) && agent.isOnNavMesh && agent.isActiveAndEnabled)
            agent.CalculatePath(hit.position, path);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            if (agent.isOnNavMesh && agent.isActiveAndEnabled)
                agent.SetPath(path);
        }
    }

    void Die()
    {
        StopAllCoroutines();
        animator.SetTrigger("Dead");
        agent.enabled = false;
        isDead = true;
        StartCoroutine(HideCorpse());
    }

    IEnumerator HideCorpse()
    {
        float t = 0;
        
        yield return new WaitForSeconds(3f);

        while (t < 2f)
        {
            transform.position += Vector3.down * Time.deltaTime;
            t += Time.deltaTime;
            yield return null;
        }
    }
    
    
    
    private void AnimateCharacter()
    {
//        Debug.Log("animate");
        animator.SetFloat("VelocityMagnitude", agent.velocity.magnitude);
      
    }
    
    private Vector3 _debugPoint;
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 0.53f, 0f);
        Gizmos.DrawSphere(_debugPoint, 1f);
    }

}
