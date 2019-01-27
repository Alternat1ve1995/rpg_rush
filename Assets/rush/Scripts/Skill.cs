using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public enum SkillType {AOE, AURA, DIRECT}
    
    public SkillEffect skillEffect;

    public int lvl;
    private int skillXP = 0;
    public int tier = 0;
    public bool isLooked = true;

    private Image img;
    private bool isTooltip = false;
    private Rect rect;

    private Vector3 startPosition;

    public GameObject tooltip;
    
    void Start()
    {
        img = GetComponent<Image>();
        img.sprite = skillEffect.sprite;
        rect = new Rect(GetComponent<RectTransform>().rect.center, new Vector2(1000, 200));
        tooltip = transform.GetChild(0).gameObject;
        tooltip.GetComponent<Text>().text = skillEffect.toolTip;
    }

    private void Update()
    {
        if (isLooked)
        {
            img.color = new Color(0.8f, 0.8f, 0.8f, 0.4f);
        }
        else
        {
            img.color = Color.white;
        }
        
        tooltip.GetComponent<Text>().text = skillEffect.toolTip + "Lvl: " + lvl + " tier: " + tier;
    }

    public void  Unlock()
    {
        isLooked = false;
    }
    
    
    public void ExecuteSkill(Character you, Character target, Vector3 point)
    {
        if (skillEffect != null && !isLooked)
        {
            skillEffect.ApplyEffect(you, target, point, lvl);
            skillXP++;
            if (skillXP > 10)
            {
                lvl++;
                skillXP = 0;
            }

            if (lvl%6 > 0)
            {
                tier++;
            }

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
    
    public void OnBeginDrag (PointerEventData eventData)
    {
//        itemBeingDragged = gameObject;
//        startPosition = transform.position;
//        startParent = transform.parent;
        startPosition = transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.position = startPosition;
        transform.position = transform.parent.position;

    }
   
}
