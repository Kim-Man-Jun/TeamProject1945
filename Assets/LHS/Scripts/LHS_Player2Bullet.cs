using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LHS_Player2Bullet : MonoBehaviour
{
    //�÷��̾� ��ġ���� ���̸�ŭ �߻�
    //���� ������?
    
    // �ٽ� ���ƿ� Ÿ��
    GameObject player;
    GameObject target;

    // �̵� �ӵ�
    public float speed = 5f;
    // ��� ��?
    public float returnSpeedMultiplier = 2f;
    // ���ƿ�
    public static bool isReturning = false;
    //���� ��ġ ����
    private Vector2 initialPosition;

    public float moveDistance = 5f; //�̵��� �Ÿ�
    Vector2 targetPosition;
    //������ġ ����
    Vector2 currentPos;
    Vector2 dirNo;

    Vector2 radiusPos;


    float x;
    float y;
    float radius;

    private void Start()
    {
        //�� ���� ��ġ ���� �ʱ���ġ ����
        //initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");

        //MoveRandomDirection();
        //AnimationCheck();
        TargetTest();

        //���������ϱ�
        float sizeOfCircle = 15f;
        float radius = GetRadius(sizeOfCircle);
        Debug.Log("���� ������: " + sizeOfCircle + "���� ������ : " + radius);
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
        //��ª���� �� �׷��� ���� ã�ƾ��� //�ٸ��Ŷ� ��ġ�� ����
        //������ ������ ����
        //Vector2 randomDrection = Random.insideUnitSphere.normalized;
        Vector2 randomDrection = Random.insideUnitSphere * 2; // ���� ����
        //���� ã�Ƽ� �߻� �� ��������?

        //randomDrection.y = 0f; //y�� �̵����� �ʵ��� ����(�����̵�?) -> �� �� �̵��ϰ� �ʹٸ�!

        targetPosition = new Vector2(transform.position.x, transform.position.y) + randomDrection.normalized * moveDistance;
        //targetPosition = new Vector2(transform.position.x * -1 , transform.position.y) * moveDistance;

    }

    private void Update()
    {
        AnimationCheck();

        initialPosition = player.transform.position;

        currentPos = transform.position;

        //�� ��ġ���� ������ �������� () ���̸�ŭ ���ٰ� �ٽ� �´�.
        if (isReturning)
        {
            float step = speed * Time.deltaTime;

            targetPosition = new Vector2(transform.position.x, transform.position.y) + dirNo;

            //����ġ���� ������ �������� () �Ÿ���ŭ
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            /* if(currentPos == targetPosition)
            {
                isReturning = false;
            }*/
        }

        else
        {
            // �ӵ��� ���� �ʱ� ��ġ
            //float step = speed * returnSpeedMultiplier * Time.deltaTime;
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

            if (currentPos == initialPosition)
            {
                TargetTest();
                //���� �� �ٽ� ����
                /*Vector3 randomDrection = Random.insideUnitSphere.normalized;
                targetPosition = new Vector3(transform.position.x, transform.position.y, 0) + randomDrection * moveDistance;*/
                Destroy(gameObject);// ���� �״ٷ�?
            }
        }
    }

    void AnimationCheck()
    {
       
        Animator anim = player.GetComponent<Animator>();
        Debug.Log(anim);

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Right"))
        {
            Debug.Log("������");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Up"))
        {
            Debug.Log("���");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Left"))
        {
            Debug.Log("����");
        }

       /* Vector2 endDrection = new Vector2(x, y);
        targetPosition = new Vector2(transform.position.x, transform.position.y) + endDrection.normalized * moveDistance;*/
    }

    void TargetTest()
    {
        target = GameObject.FindGameObjectWithTag("Monster");

        targetPosition = target.transform.position - transform.position;
        //dirNo = targetPosition.normalized;

        Debug.Log("Ȯ�� :" + targetPosition);
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
