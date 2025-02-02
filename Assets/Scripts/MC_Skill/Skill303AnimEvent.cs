using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill303AnimEvent : FieldSkillBase
{

    [SerializeField]
    private float colliderLastTime;
    // Start is called before the first frame update
    
    private void ColliderOpen()
    {
        range = PlayerController.Instance.GetPlayerSkillRange();
        transform.localScale = new Vector3(Mathf.Pow(1.1f,range), Mathf.Pow(1.1f, range), Mathf.Pow(1.1f, range));
        //Debug.Log("fo range =" + range);
        damage = 0.5f * PlayerController.Instance.GetPlayerHealthFinal();
        this.GetComponent<CircleCollider2D>().enabled = true;
        Invoke(nameof(CloseCollider), colliderLastTime);
    }
    
    private void CloseCollider()
    {
        
        this.GetComponent<CircleCollider2D>().enabled = false;
        //Debug.Log(this.GetComponent<CircleCollider2D>().enabled);
    }
}
