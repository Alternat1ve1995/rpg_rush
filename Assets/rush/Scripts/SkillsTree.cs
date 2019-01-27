using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsTree : MonoBehaviour
{
    public Character player;

    public Skill[] skills;

    public Text numberOfPoints;

    private void Update()
    {
        numberOfPoints.text = "Points : " + player.stats.talentPoints;
        if (Input.GetKeyDown("s"))
        {
            bool f = transform.GetChild(0).gameObject.activeSelf;
            transform.GetChild(0).gameObject.SetActive(!f);
        }
    }

    public void UnlockSkill(int num)
    {
        Debug.Log("Skill " + skills[num].skillEffect.name + " trying t unlick!!");
        if (num < skills.Length)
        {
            if (skills[num].isLooked)
            {
                if (player.stats.talentPoints >= 5)
                {
                    skills[num].isLooked = false;
                    player.stats.talentPoints -= 5;
                    Debug.Log("Skill " + skills[num].skillEffect.name + " unlocked!!");
                }
                else
                {
                    Debug.Log("no points");

                }
            }
            else
            {
                Debug.Log("alreadyUnlock");

            }
            
        }
        else
        {
            Debug.Log("bad number");

        }

        
    }
}
