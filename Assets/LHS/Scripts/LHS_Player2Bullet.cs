using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LHS_Player2Bullet : MonoBehaviour
{
    public float speed = 5f;
    public int Attack = 10;

    //부메랑
    public static bool isReturning = false;

    // 다시 돌아올 타겟
    GameObject player;
    GameObject target;

    public float moveDistance = 5f; //이동할 거리

    Vector2 initialPosition; //초기 위치 저장
    Vector2 targetPosition; //타겟 위치 저장
    Vector2 currentPos; //현재 위치 저장

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //적 찾기
        TargetTest();

        //랜덤값으로 (보류)
        //MoveRandomDirection();
    }

    void MoveRandomDirection()
    {
        //※짧은건 왜 그런지 오류 찾아야함 //다른거랑 겹치기 싫음
        //랜덤한 방향을 생성
        //Vector2 randomDrection = Random.insideUnitSphere.normalized;
        Vector2 randomDrection = Random.insideUnitSphere * 2; // 랜덤 말고
        //적을 찾아서 발사 적 방향으로?

        //randomDrection.y = 0f; //y축 이동하지 않도록 설정(수평이동?) -> 난 다 이동하고 싶다면!

        targetPosition = new Vector2(transform.position.x, transform.position.y) + randomDrection.normalized * moveDistance;
    }

    private void Update()
    {
        //플레이어 애니메이션 확인 (보류)
        AnimationCheck();

        //플레이어 위치
        initialPosition = player.transform.position;

        //현재 내 위치
        currentPos = transform.position;

        //부메랑
        if (isReturning)
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);

            if (currentPos == targetPosition)
            {
                isReturning = false;
            }
        }

        else
        {
            // 속도를 높여 초기 위치(보류)
            //float step = speed * returnSpeedMultiplier * Time.deltaTime;
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

            if (currentPos == initialPosition)
            {
                TargetTest();

                //Destroy(gameObject);// 삭제

                //랜덤 값 다시 지정
                /*Vector3 randomDrection = Random.insideUnitSphere.normalized;
                targetPosition = new Vector3(transform.position.x, transform.position.y, 0) + randomDrection * moveDistance;*/
            }
        }
    }

    //몬스터 찾기
    void TargetTest()
    {
        target = GameObject.FindGameObjectWithTag("Monster");

        if(target != null)
        {
            //몬스터 방향
            targetPosition = target.transform.position - transform.position;
            //targetPosition = new Vector2(target.transform.position.x, target.transform.position.y);

            targetPosition = new Vector2(transform.position.x, transform.position.y) + targetPosition.normalized * moveDistance;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<LHS_Monster1>().Damage(Attack);
        }

        if(collision.gameObject.CompareTag("Monster2"))
        {
            collision.gameObject.GetComponent<LHS_Monster2>().Damage(Attack);
        }
    }

    void AnimationCheck()
    {
        Animator anim = player.GetComponent<Animator>();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Right"))
        {
            //Debug.Log("오른쪽");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Up"))
        {
            //Debug.Log("가운데");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Left"))
        {
            //Debug.Log("왼쪽");
        }
    }
}
