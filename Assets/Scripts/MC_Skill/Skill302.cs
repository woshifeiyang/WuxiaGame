using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill302 : FieldSkillBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        GameObject.Find("SkillManager").GetComponent<Cure>().EnableCure();
        
    }

    public override void Update()
    {
        this.transform.localScale = new Vector3(range, range, 1f);
    }


}
