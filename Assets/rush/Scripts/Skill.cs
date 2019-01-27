using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    //public delegate void SkillFunc(GameObject you, GameObject target, Vector3 point);
    public enum SkillType {AOE, AURA, DIRECT}
    
    //public SkillFunc skill;
    public SkillEffect skillEffect;

    public int lvl;
    public int tier;

    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = skillEffect.sprite;
    }
    
    public void ExecuteSkill(Character you, Character target, Vector3 point)
    {
        if (skillEffect != null)
        {
            skillEffect.ApplyEffect(you, target, point, lvl);
        }
    }
}
