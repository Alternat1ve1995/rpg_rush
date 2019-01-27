using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //public delegate void SkillFunc(GameObject you, GameObject target, Vector3 point);
    public enum SkillType {AOE, AURA, DIRECT}
    
    //public SkillFunc skill;
    public SkillEffect skillEffect;

    public int lvl;
    public int tier;
    public bool isLooked;

    private Image img;
    private bool isTooltip = false;
    private Rect rect;

    public GameObject tooltip;
    
    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = skillEffect.sprite;
        rect = new Rect(GetComponent<RectTransform>().rect.center, new Vector2(1000, 200));
        tooltip = transform.GetChild(0).gameObject;
        tooltip.GetComponent<Text>().text = skillEffect.toolTip;
    }
    
    public void ExecuteSkill(Character you, Character target, Vector3 point)
    {
        if (skillEffect != null)
        {
            Debug.Log("Skill 0 have effect");
            skillEffect.ApplyEffect(you, target, point, lvl);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("Toool tip show");
        isTooltip = true;
        tooltip.SetActive((true));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("Toool tip hide");
        isTooltip = false;
        tooltip.SetActive((false));
    }

   
}
