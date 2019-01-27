using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    [SerializeField] private Text lvl;
    [SerializeField] private Text str;
    [SerializeField] private Text agi;
    [SerializeField] private Text con;
    [SerializeField] private Text armor;
    [SerializeField] private Text hp;
    [SerializeField] private Text minD;
    [SerializeField] private Text maxD;
    [SerializeField] private Text credit;

    [SerializeField] private Character c;
    
    void Update()
    {
        if (c.stats != null)
            SetStats();
        if (Input.GetKeyDown("c"))
        {
            bool f = transform.GetChild(0).gameObject.activeSelf;
            transform.GetChild(0).gameObject.SetActive(!f);
        }
    }

    void SetStats()
    {
        lvl.text = "LVL: " + c.stats.lvl;
        str.text = "STR: " + c.stats.STR;
        agi.text = "AGI: " + c.stats.AGI;
        con.text = "CON: " + c.stats.CON;
        armor.text = "Armor: " + c.stats.armor;
        hp.text = "HP: " + c.stats.maxHP;
        minD.text = "Min_Damage: " + c.stats.minDamage;
        maxD.text = "Max_Damage: " + c.stats.maxDamage;
        credit.text = "Credit: " + c.stats.credit;
    }
    
}
