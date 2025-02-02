using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill201 : MultTargetSkillBase
{
    public float fixedDamage = 150;
    public override void Start()
    {
        damage = fixedDamage;
        bool dou = GameObject.Find("SkillManager").GetComponent<DouStk>().GetDou();
        //Debug.Log("dou" + dou);
        if (dou)
        {
            if (Random.value > 0.5)
            {
                Invoke("Lightcall1", 0.3f);
            }
        }
        
    }

    private void Lightcall1()
    {
        GameObject.Find("SkillManager").GetComponent<Strike>().Lightcall1();
    }

    private void Lightcall()
    {
        GameObject.Find("SkillManager").GetComponent<Strike>().Lightcall();
    }

    private void SelfDestory()
    {
        Destroy(gameObject);
    }

    
    
}
