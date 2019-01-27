using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundDamageSkill : SkillEffect

{
    private GameObject particleGO;

    private Coroutine doCor;
    
    public override  void ApplyEffect(Character you, Character target, Vector3 point, int lvl)
    {
        

        if (doCor == null)
            doCor = StartCoroutine(Do(you, target, lvl));
        else
        {
            if (particleGO != null)
                Destroy(particleGO);
            
            StopCoroutine(doCor);
            doCor = StartCoroutine(Do(you, target, lvl));
            
        }
    }


    IEnumerator Do(Character you,Character target, int lvl)
    {
        
        //Debug.Log("AOE!!!");
        particleGO = Instantiate(particle, you.transform.position, Quaternion.identity, you.transform);
        if (target != null)
            if (Vector3.Distance(target.transform.position, particleGO.transform.position) <= 10)
                target.TakeDamage(10 + lvl * 5);
        yield return new WaitForSeconds(4 + 2 * lvl);
        Destroy(particleGO);
        
        Debug.Log("AOE End");
    }
}
