using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSkill :  SkillEffect
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
        you.stats.STR += (10 + lvl * 5);
        you.stats.Generate();
        yield return new WaitForSeconds(10 + 2 * lvl);
        you.stats.STR -= (10 + lvl * 5);
        you.stats.Generate();
        Destroy(particleGO);
        
    }
}
