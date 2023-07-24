using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이동, 애니메이션 필요
public class LHS_Player2Move : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h < 0)
        {
            anim.SetBool("Left", true);
        }

        if (h > 0)
        {
            anim.SetBool("Right", true);
        }


        Vector3 dir = new Vector3(h, v, 0);
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;
    }
}
