using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : Character
{
    private Coroutine attackingCoroutine;
    public GameObject potionPrefab;

    private void Start()
    {
        
        Debug.Log(stats.lvl);
    }

    private void Update()
    {
        if (hp <= 0 && !isDead)
            Die();

        AnimateCharacter();
        CheckTarget();

    }

    void CheckTarget()
    {
        if (target != null && HowNear(transform, target.transform) <= attackRange)
        {
            if (agent.isOnNavMesh && agent.isActiveAndEnabled)
            {
                //Attack
                if (attackingCoroutine == null)
                    attackingCoroutine = StartCoroutine(Attacking());
                agent.destination = transform.position;
                agent.isStopped = true;
            }
        }
        else if (target != null)
        {
            if (agent.isOnNavMesh && agent.isActiveAndEnabled)
                agent.isStopped = false;
            if (agent.isOnNavMesh && agent.isActiveAndEnabled)
                agent.destination = target.transform.position;
        }
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
                yield return new WaitForSeconds(0.4f);
                float damage = GetDamage();
//                Debug.Log(damage);
                target.TakeDamage(damage);
            }
            if (target.hp <= 0)
                break;
            yield return null;
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerCharacter>();
        
        if (player == null) return;
        target = player;
    }
    
    
    void Die()
    {
        isDead = true;
        StopAllCoroutines();
        animator.SetTrigger("Dead");
        agent.enabled = false;
        StartCoroutine(HideCorpse());
    }

    IEnumerator HideCorpse()
    {
        float t = 0;
        
        yield return new WaitForSeconds(3f);

        if (potionPrefab != null)
            Instantiate(potionPrefab, transform.position, Quaternion.identity);
        while (t < 2f)
        {
            transform.position += Vector3.down * Time.deltaTime;
            t += Time.deltaTime;
            yield return null;
        }

        animator.enabled = false;
        if (target)
        {
            target.GetComponent<PlayerCharacter>().exp += 150;
            target.GetComponent<PlayerCharacter>().stats.credit += stats.credit;
        }
        
        Destroy(gameObject);
    }
    
    
    
    private void AnimateCharacter()
    {
        //Debug.Log("animate");
        animator.SetFloat("VelocityMagnitude", agent.velocity.magnitude);
      
    }
}
