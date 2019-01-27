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
        if (targetSpherePrefab)
            go = Instantiate(targetSpherePrefab);

        if (doCor == null)
            doCor = StartCoroutine(Do(you, lvl));
    }


    IEnumerator Do(Character you, int lvl)
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

        particleGO = Instantiate(particle);
        particleGO.transform.position = go.transform.position;
        yield return new WaitForSeconds(2 * lvl);
        Destroy(particleGO);
    }
}
