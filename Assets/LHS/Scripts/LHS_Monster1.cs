using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LHS_Monster1 : MonoBehaviour
{
    //플레이어를 따라다니며 죽일예정 ~~~ 

    // 다시 돌아올 타겟
    public Transform target;
    public float speed;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = transform.position.x;
        float v = transform.position.y;

        //작아지면 Right 
        if( h >= 0.05f )
        {
            anim.SetBool("Right", true);
        }
        else
        {
            anim.SetBool("Right", false);
        }
        if( h <= -0.05f)
        {
            anim.SetBool("Left", true);
        }
        else
        {
            anim.SetBool("Left", false);
        }

        //Vector3 dir = target.position - transform.position;
        transform.position = Vector3.Lerp(transform.position, target.transform.position - new Vector3(2, 0, 0), speed);

        //transform.Translate(dir * speed * Time.deltaTime);
    }
}
