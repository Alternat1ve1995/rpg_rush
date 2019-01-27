using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public HUDController hud;
    public int hp;
    public int exp = 0;
    public int attackRange = 3;
    
    
    public NavMeshAgent agent;
    public Animator animator;
    public Character target;
    public bool isDead = false;

    public GameObject lvlupPrefab;
    public Stats stats;
    
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        hud.ToggleActive(false);
        stats.Generate();
        hp = stats.maxHP;        
    }

    void FixedUpdate()
    {
        if (exp > stats.xpToNext)
        {
            stats.LvlUP();
            hp = stats.maxHP;
            exp = exp - stats.xpToNext;
            if (exp < 0) exp = 0;
            if (lvlupPrefab != null)
                Instantiate(lvlupPrefab, transform.position, Quaternion.identity);
        }

        if (hud != null)
        {
            hud.SetHP(hp, stats.maxHP);
            hud.SetXP(exp, stats.lvl, stats.xpToNext);
        }
    }

    public float CalculateDamage(Stats a, Stats enemy)
    {
        float hitChance = 75 + a.AGI - enemy.AGI;
        if (Random.Range(0, 100) <= hitChance)
        {
            float basicD = Random.Range(a.minDamage, a.maxDamage);
            return basicD * (1 - enemy.armor / 200);
        }
        else
            return 0;
    }
    
    public void TakeDamage(float damage)
    {
        hp -= (int)damage;
    }

    public float HowNear(Transform a, Transform b)
    {
        return (a.position - b.position).magnitude;
    }
   
}
