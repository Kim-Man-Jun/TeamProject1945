using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이동, 애니메이션 필요
public class LHS_Player2Move : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] GameObject bulletFactory;

    //총알발사

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    void Update()
    {
        Physics2D.Linecast(transform.position, transform.position + (transform.up * 1.5f));
        Debug.DrawLine(transform.position, transform.position + (transform.up * 1.5f));

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveX = h * moveSpeed * Time.deltaTime;
        float moveY = v * moveSpeed * Time.deltaTime;

        #region 애니메이션 적용
        if(h >= 0.5f)
        {
            anim.SetBool("Right", true);
        }
        else
        {
            anim.SetBool("Right", false);
        }
        if(h <= -0.5f)
        {
            anim.SetBool("Left", true);
        }
        else
        {
            anim.SetBool("Left", false);
        }
        #endregion


        Vector3 dir = new Vector3(h, v, 0);
        dir.Normalize();
        transform.position += dir * moveSpeed * Time.deltaTime;

        //transform.Translate(moveX, moveY, 0);

        if(Input.GetButtonDown("Jump"))
        {
            /*Vector3 pos = new Vector3(transform.position.x, transform.position.y + 3, 0);
            GameObject bullt = Instantiate(bulletFactory, pos, Quaternion.identity);*/
            LHS_Player2Bullet.isReturning = true;

        }
    }
}
