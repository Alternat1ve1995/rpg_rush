using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] Slider xpSlider;

    [SerializeField] Text hpText;
    [SerializeField] Text xpText;


    private void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0f, 180, 0f);
    }

    public void ToggleActive(bool isActive)
    {
        transform.GetChild(0).gameObject.SetActive(isActive);
    }
    
    public void SetXP(int xp, int lvl, int maxXP)
    {
        xpSlider.value = xp;
        xpText.text = "Lvl:  " + lvl + " ( " + xp + " / " + maxXP + ")";
    }

    public void SetHP(int hp, int maxHp)
    {
        hpSlider.maxValue = maxHp;
        hpSlider.value = hp;
        hpText.text = "HP: " + hp + " / " + maxHp;
        
    }
}
