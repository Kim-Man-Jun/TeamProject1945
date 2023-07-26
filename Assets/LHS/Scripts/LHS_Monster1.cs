using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//1단계 적
//플레이어를 따라다닌다 -> 일정한 간격을 둔다 (애니메이션)
//총을 발사한다.
public class LHS_Monster1 : MonoBehaviour
{
    [Header("이동속도")]
    [SerializeField] float speed;

    GameObject target;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    { 
        #region 애니메이션
        //벡터의 뺄셈 이용한 애니메이션 처리
        //플레이어가 어느 방향쪽에 있는지 체크 
        //이후 애니메이션 바꾸기
        Vector3 dir = target.transform.position - transform.position;

        if(dir.x > 0.5f )
        {
            //+ 오른쪽으로 가야함
            anim.SetBool("Right", true);
        }
        else
        {
            anim.SetBool("Right", false);
        }
        if (dir.x < 0.5f)
        {
            anim.SetBool("Left", true);
        }
        else
        {
            anim.SetBool("Left", false);
        }
        #endregion

        //transform.position = Vector3.Lerp(transform.position, target.transform.position - new Vector3(2, 0, 0), speed);

        transform.Translate(dir * speed * Time.deltaTime);
    }
}
