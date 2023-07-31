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

    //�θ޶�
    public static bool isReturning = false;

    // �ٽ� ���ƿ� Ÿ��
    GameObject player;
    GameObject target;

    public float moveDistance = 5f; //�̵��� �Ÿ�

    Vector2 initialPosition; //�ʱ� ��ġ ����
    Vector2 targetPosition; //Ÿ�� ��ġ ����
    Vector2 currentPos; //���� ��ġ ����

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //�� ã��
        TargetTest();

        //���������� (����)
        //MoveRandomDirection();
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
    }

    private void Update()
    {
        //�÷��̾� �ִϸ��̼� Ȯ�� (����)
        AnimationCheck();

        //�÷��̾� ��ġ
        initialPosition = player.transform.position;

        //���� �� ��ġ
        currentPos = transform.position;

        //�θ޶�
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
            // �ӵ��� ���� �ʱ� ��ġ(����)
            //float step = speed * returnSpeedMultiplier * Time.deltaTime;
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

            if (currentPos == initialPosition)
            {
                TargetTest();

                //Destroy(gameObject);// ����

                //���� �� �ٽ� ����
                /*Vector3 randomDrection = Random.insideUnitSphere.normalized;
                targetPosition = new Vector3(transform.position.x, transform.position.y, 0) + randomDrection * moveDistance;*/
            }
        }
    }

    //���� ã��
    void TargetTest()
    {
        target = GameObject.FindGameObjectWithTag("Monster");

        if(target != null)
        {
            //���� ����
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
            //Debug.Log("������");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Up"))
        {
            //Debug.Log("���");
        }

        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Player2_Left"))
        {
            //Debug.Log("����");
        }
    }
}
