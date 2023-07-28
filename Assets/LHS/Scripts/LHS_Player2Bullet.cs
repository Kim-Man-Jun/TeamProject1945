using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LHS_Player2Bullet : MonoBehaviour
{
    //플레이어 위치에서 길이만큼 발사
    //각도 설정은?
    
    // 다시 돌아올 타겟
    GameObject player;
    GameObject target;

    // 이동 속도
    public float speed = 5f;
    // 얘는 왜?
    public float returnSpeedMultiplier = 2f;
    // 돌아옴
    public static bool isReturning = false;
    //간격 위치 저장
    private Vector2 initialPosition;

    public float moveDistance = 5f; //이동할 거리
    Vector2 targetPosition;
    //현재위치 저장
    Vector2 currentPos;
    Vector2 dirNo;

    Vector2 radiusPos;


    float x;
    float y;
    float radius;

    private void Start()
    {
        //내 원래 위치 저장 초기위치 저장
        //initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

        //MoveRandomDirection();
        //AnimationCheck();
        TargetTest();

        //반지름구하기
        float sizeOfCircle = 15f;
        float radius = GetRadius(sizeOfCircle);
        Debug.Log("원의 사이즈: " + sizeOfCircle + "원의 반지름 : " + radius);
    }

    float GetRadius(float size)

    {
        float pi = 3.14f;
        float tmp = size / pi;
        float radius = Mathf.Sqrt(tmp);
        radiusPos = new Vector2(radius, radius);
        return radius;
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
        //targetPosition = new Vector2(transform.position.x * -1 , transform.position.y) * moveDistance;

    }

    private void Update()
    {
        AnimationCheck();

        initialPosition = player.transform.position;

        currentPos = transform.position;

        //내 위치에서 랜덤한 방향으로 () 길이만큼 갔다가 다시 온다.
        if (isReturning)
        {
            float step = speed * Time.deltaTime;

            targetPosition = new Vector2(transform.position.x, transform.position.y) + dirNo;

            //내위치에서 랜덤한 방향으로 () 거리만큼
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            /* if(currentPos == targetPosition)
            {
                isReturning = false;
            }*/
        }

        else
        {
            // 속도를 높여 초기 위치
            //float step = speed * returnSpeedMultiplier * Time.deltaTime;
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

            if (currentPos == initialPosition)
            {
                TargetTest();
                //랜덤 값 다시 지정
                /*Vector3 randomDrection = Random.insideUnitSphere.normalized;
                targetPosition = new Vector3(transform.position.x, transform.position.y, 0) + randomDrection * moveDistance;*/
                Destroy(gameObject);// 껐다 켰다로?
            }
        }
    }

    void AnimationCheck()
    {
       
        Animator anim = player.GetComponent<Animator>();
        Debug.Log(anim);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Right"))
        {
            Debug.Log("오른쪽");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Up"))
        {
            Debug.Log("가운데");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Left"))
        {
            Debug.Log("왼쪽");
        }

       /* Vector2 endDrection = new Vector2(x, y);
        targetPosition = new Vector2(transform.position.x, transform.position.y) + endDrection.normalized * moveDistance;*/
    }

    void TargetTest()
    {
        target = GameObject.FindGameObjectWithTag("Monster");

        targetPosition = target.transform.position - transform.position;
        //dirNo = targetPosition.normalized;

        Debug.Log("확인 :" + targetPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
        }
    }

    /*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
        }
    }*/
}
