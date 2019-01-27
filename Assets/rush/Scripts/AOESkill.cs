using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOESkill : SkillEffect
{
    public GameObject targetSpherePrefab;

    private GameObject go;
    private GameObject particleGO;

    private Coroutine doCor;
    
    public override  void ApplyEffect(Character you, Character target, Vector3 point, int lvl)
    {
        if (targetSpherePrefab != null)
            go = Instantiate(targetSpherePrefab);

        if (doCor == null)
            doCor = StartCoroutine(Do(you, target, lvl));
        else
        {
            if (particleGO != null)
                Destroy(particleGO);
            if (go != null)
                Destroy(go);
            StopCoroutine(doCor);
            doCor = StartCoroutine(Do(you, target, lvl));
            
        }
    }


    IEnumerator Do(Character you,Character target, int lvl)
    {
        while (!Input.GetMouseButtonDown(0))
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("AOE");
            if (Physics.Raycast (camRay, out hit, 10000, you.FloorMask))
            {
                if (go)
                    go.transform.position = hit.point;
            }
            
            yield return null;
        }
        //Debug.Log("AOE!!!");
        particleGO = Instantiate(particle);
        particleGO.transform.position = go.transform.position;
        Destroy(go);
        if (target != null)
            if (Vector3.Distance(target.transform.position, particleGO.transform.position) <= 10)
                target.TakeDamage(10 + lvl * 5);
        yield return new WaitForSeconds(4 + 2 * lvl);
        Destroy(particleGO);
        
        Debug.Log("AOE End");
    }
}
