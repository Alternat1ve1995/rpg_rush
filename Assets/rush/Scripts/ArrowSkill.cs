using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSkill : SkillEffect
{
    private GameObject arrow;
    
    private Coroutine doCor;
    
    
    public override void ApplyEffect(Character you, Character target, Vector3 point, int lvl)
    {
        if (target == null)
            return;

        Debug.Log("Arrow");
        arrow = Instantiate(particle, you.transform.position, you.transform.rotation);
        
        if (doCor == null)
            doCor = StartCoroutine(Do(you, target, lvl));
    }
    
    IEnumerator Do(Character you, Character target, int lvl)
    {
        float startTime = Time.time;
        while (Time.time - startTime < 4 + lvl * 2)
        {
            if (target != null)
            {
                Vector3 dir = (target.transform.position - arrow.transform.position).normalized * Time.deltaTime * (100 + lvl * 2);
                arrow.transform.Translate(dir);
            }
            
            yield return null;
        }
        target.TakeDamage(10 + lvl * 5);
        Destroy(arrow);
        
    }
    
}
