using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BossMoving : MonoBehaviour
{
    //���� �Ӹ��� ���ư��� ���� ���� �ִϸ��̼�
    Animator animator;
    public Vector2 PlayerVector;
    public Vector2 BossVector;

    //���� �� ������ ����
    public float distanceBetween = 0.2f;
    public float Speed = 200;
    public float turnSpeed = 180;
    public List<GameObject> bodyParts = new List<GameObject>();
    List<GameObject> BossBody = new List<GameObject>();

    float countUp = 0;

    Transform basicPos;

    //���� ������ ����
    public Vector2 Target;
    public float minX = -1.35f;
    public float maxX = 1.35f;
    public float minY = -20f;
    public float maxY = -17.53f;

    public float BossMovingSpeed = 4;

    //���� ������Ʈ�� ó�� ��ġ ����
    private void Awake()
    {
        basicPos = this.gameObject.transform;
    }

    //�ִϸ����� ������Ʈ�� ���� ���� ����, ���� ������
    void Start()
    {
        animator = GetComponent<Animator>();

        //�� ������ ����
        CreateBodyParts();
        
        //���� �������� �ڷ�ƾ
        StartCoroutine("BossRandomMoving");
    }

    IEnumerator BossRandomMoving()
    {
        float rndX = Random.Range(minX, maxX);
        float rndY = Random.Range(minY, maxY);

        Target = new Vector2(rndX, rndY);

        gameObject.transform.position = Vector2.MoveTowards(
            transform.position, Target, BossMovingSpeed * Time.deltaTime);
        yield return new WaitForSeconds(0.8f);
        StartCoroutine("BossRandomMoving");
    }

    void CreateBodyParts()
    {
        if (BossBody.Count == 0)
        {
            GameObject temp1 = Instantiate(bodyParts[0], transform.position,
                transform.rotation, transform);
            if (!temp1.GetComponent<MarkerManager>())
            {
                temp1.AddComponent<MarkerManager>();
            }
            if (!temp1.GetComponent<Rigidbody2D>())
            {
                temp1.AddComponent<Rigidbody2D>();
                temp1.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
            BossBody.Add(temp1);
            bodyParts.RemoveAt(0);
        }

        MarkerManager markM = BossBody[BossBody.Count - 1].
            GetComponent<MarkerManager>();

        if (countUp == 0)
        {
            markM.ClearMarkerList();
        }
        countUp += Time.deltaTime;

        if (countUp >= distanceBetween)
        {

            GameObject temp = Instantiate(bodyParts[0], markM.markerList[0].position,
                markM.markerList[0].rotation, transform);
            if (!temp.GetComponent<MarkerManager>())
            {
                temp.AddComponent<MarkerManager>();
            }
            if (!temp.GetComponent<Rigidbody2D>())
            {
                temp.AddComponent<Rigidbody2D>();
                temp.GetComponent<Rigidbody2D>().gravityScale = 0;
            }

            BossBody.Add(temp);
            bodyParts.RemoveAt(0);
            temp.GetComponent<MarkerManager>().ClearMarkerList();
            countUp = 0;
        }
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerVector = player.GetComponent<Transform>().position;
        BossVector = GetComponent<Transform>().position;

        float angle = GetAngle(PlayerVector, BossVector);

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

        if (transform.position.x <= -1.35f)
        {
            transform.position = new Vector3(-1.35f, transform.position.y, 0);
        }
        if (transform.position.x >= 1.35f)
        {
            transform.position = new Vector3(1.35f, transform.position.y, 0);
        }
        if (transform.position.y >= -17.54f)
        {
            transform.position = new Vector3(transform.position.x, -17.54f, 0);
        }
        if (transform.position.y <= -20f)
        {
            transform.position = new Vector3(transform.position.x, -20f, 0);
        }

        gameObject.transform.position = Vector2.MoveTowards(
            transform.position, Target, BossMovingSpeed * Time.deltaTime);
        //�� ����� �ȵǴ��� �𸣰���..

        if(BossController.BossNowHp <= 0)
        {
            BossMoving bossMoving = GetComponent<BossMoving>();
            Destroy(bossMoving);
        }
    }

    private void FixedUpdate()
    {
        BossMovement();
        ManageBossBody();
    }

    void BossMovement()
    {
        //BossBody[0].GetComponent<Rigidbody2D>().velocity = BossBody[0].transform.right * Speed * Time.deltaTime;
        if (this.gameObject.transform != basicPos)
        {
            BossBody[0].transform.Rotate(new Vector3(0, 0, -turnSpeed
                * Time.deltaTime));
        }

        if (BossBody.Count > 1)
        {
            for (int i = 1; i < BossBody.Count; i++)
            {
                MarkerManager markM = BossBody[i - 1].GetComponent<MarkerManager>();
                BossBody[i].transform.position = markM.markerList[i - 1].position;
                BossBody[i].transform.rotation = markM.markerList[i - 1].rotation;
                markM.markerList.RemoveAt(0);
            }
        }
    }

    void ManageBossBody()
    {
        if (bodyParts.Count > 0)
        {
            CreateBodyParts();
        }
        for (int i = 0; i < BossBody.Count; i++)
        {
            if (BossBody[i] == null)
            {
                BossBody.RemoveAt(i);
                i = i - 1;
            }
        }
    }

    //���� ����
    public static float GetAngle(Vector2 vStart, Vector2 vEnd)
    {
        Vector2 v = vEnd - vStart;          //���� v ���� 
        return Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
    }

    public void AddBodyParts(GameObject obj)
    {
        bodyParts.Add(obj);
    }
}
