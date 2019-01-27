using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public Skill.SkillType skillType;
   
    public string name;
    public string toolTip;
    public Sprite sprite;
    public GameObject particle;
    
    public virtual void ApplyEffect(Character you, Character target, Vector3 point, int lvl)
    {
    }
}
