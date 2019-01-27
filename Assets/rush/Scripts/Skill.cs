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
    public int tier;
    public bool isLooked;

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
