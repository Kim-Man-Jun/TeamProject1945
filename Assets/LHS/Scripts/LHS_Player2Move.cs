using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이동, 애니메이션
//총알발사
public class LHS_Player2Move : MonoBehaviour
{
    //이동속도
    [Header("이동속도")]
    [SerializeField] float moveSpeed = 5f;
    //총알공장
    [Header("총알프리팹")]
    [SerializeField] GameObject bulletFactory;

    Animator anim;

    //player움직임 
    public bool startGame = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Intro();

        #region Linecast Test
        //Linecast -> 테스트용이라면 그리기가 가능?
        //Linecast 길이만큼 선을 그린다? 아님 나가는 걸로 따라서 선 그리기? 
        //Rotate도 돌릴 수 있나?
        Physics2D.Linecast(transform.position, transform.position + (transform.up * 1.5f));
        Debug.DrawLine(transform.position, transform.position + (transform.up * 1.5f));
        #endregion

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveX = h * moveSpeed * Time.deltaTime;
        float moveY = v * moveSpeed * Time.deltaTime;

        if (startGame == true)
        {
            #region 애니메이션 적용
            if (h >= 0.5f)
            {
                anim.SetBool("Right", true);
            }
            else
            {
                anim.SetBool("Right", false);
            }

            if (h <= -0.5f)
            {
                anim.SetBool("Left", true);
            }
            else
            {
                anim.SetBool("Left", false);
            }
            #endregion

            #region 이동
            //벡터의 양과 상관없이 일관적인 속도를 적용시키기 위해서는 
            //벡터의 크기를 1로 바꿔주는 normalized를 활용 -> 대각선이동
            //방법1
            /*Vector3 dir = new Vector3(h, v, 0);
            dir.Normalize();
            transform.position += dir * moveSpeed * Time.deltaTime;*/

            //방법2
            //게임 시작 후에만 움직임 가능
            transform.Translate(new Vector3(h, v, 0).normalized * moveSpeed * Time.deltaTime);

            //이동 막기 x축 2.45
            if (transform.position.x >= 2.45f)
            {
                transform.position = new Vector3(2.45f, transform.position.y, 0);
            }
            else if (transform.position.x <= -2.45f)
            {
                transform.position = new Vector3(-2.45f, transform.position.y, 0);
            }
            #endregion
        }

        //총알공격 -> 내 앞에 가져다 놓는다.
        // = Input.GetKeyDown(KeyCode.Space)
        if (Input.GetButtonDown("Jump"))
        {
            GameObject bullt = Instantiate(bulletFactory,transform.position, Quaternion.identity);
            
            LHS_Player2Bullet.isReturning = true;
        }
    }

    void Intro()
    {
        if (startGame == false)
        {
            //시작할때 게임 위치로 이동 //숫자로 할수도 있고, 위치 지정도 가능
            //지점 도착 이후 이동가능
            Vector3 endPos = new Vector3(0, -4, 0);

            //시작지점, 목표지점, 이동속도
            transform.position = Vector3.MoveTowards(transform.position, endPos, 0.1f);

            if (transform.position == endPos)
            {
                startGame = true;
            }
        }
    }
}
