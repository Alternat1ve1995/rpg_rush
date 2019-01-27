using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    public int STR;
    public int AGI;
    public int CON;
    
    public int armor;
    public int lvl;
    public int xpToNext;
    public int credit;
    public int talentPoints;
    
    [HideInInspector]public int maxHP;
    [HideInInspector]public int minDamage;
    [HideInInspector]public int maxDamage;

    public void Generate()
    {
        maxHP = 5 * CON;
        minDamage = STR / 2;
        maxDamage = minDamage + 4;
    }

    public void LvlUP()
    {
        STR += (int)(STR * 0.2f);
        AGI += (int)(AGI * 0.2f);
        CON += (int)(CON * 0.2f);
        lvl += 1;
        xpToNext *= 2;
        credit += 5;
        talentPoints += 5;
        Generate();
    }

    public void SetLevel(int toLvl)
    {
        while (lvl < toLvl)
        {
            LvlUP();
        }
    }
}
