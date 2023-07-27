using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossMoving : MonoBehaviour
{
    //보스 머리통 돌아가는 각도 계산과 애니메이션
    Animator animator;
    public Vector2 PlayerVector;
    public Vector2 BossVector;

    //보스 뱀 움직임 관련
    public float Speed = 2;
    public float turnSpeed = 180;
    public List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> BossBody = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //뱀 움직임 관련
        GameObject temp = Instantiate(bodyParts[0], transform.position,
            transform.rotation, transform);

        if (!temp.GetComponent<Rigidbody2D>())
        {
            temp.AddComponent<Rigidbody2D>();
            temp.GetComponent<Rigidbody2D>().gravityScale = 0;
        }

        BossBody.Add(temp);

        StartCoroutine("BossRandomMoving");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerVector = player.GetComponent<Transform>().position;
        BossVector = GetComponent<Transform>().position;

        float angle = GetAngle(PlayerVector, BossVector);
        print(angle);

        if (angle > 80 && angle < 100)
        {
            animator.Play("BossIdle");
        }
        else if (angle >= -20 && angle < 80)
        {
            animator.Play("BossLeft");
        }
        else if (angle <= -145 || angle > 100)
        {
            animator.Play("BossRight");
        }
        else
        {
            animator.Play("BossBack");
        }
    }

    private void FixedUpdate()
    {
        BossMovement();
    }

    void BossMovement()
    {
        BossBody[0].GetComponent<Rigidbody2D>().velocity =
            BossBody[0].transform.right * Speed * Time.deltaTime;
    }

    IEnumerator BossRandomMoving()
    {
        int rndX = Random.Range(-1, 2);
        int rndY = Random.Range(-1, 2);

        //움직임은 수정할 예정
        transform.Translate(rndX * Speed * Time.deltaTime, rndY * Speed * Time.deltaTime, 0);

        yield return new WaitForSeconds(2f);
        StartCoroutine("BossRandomMoving");
    }


    public static float GetAngle(Vector2 vStart, Vector2 vEnd)
    {
        Vector2 v = vEnd - vStart;          //변수 v 생성 
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }
}
