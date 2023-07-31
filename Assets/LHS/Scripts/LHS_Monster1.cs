using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

//1�ܰ� ��
//�÷��̾ ����ٴѴ� -> ������ ������ �д� (�ִϸ��̼�)
//���� �߻��Ѵ�.
public class LHS_Monster1 : MonoBehaviour
{
    [Header("�̵�")]
    [SerializeField] float speed = 3;
    [SerializeField] float length = 3.0f; //�Ÿ�
    [Header("�߻�")]     //�� �ִϸ��̼Ǹ��� �ٸ� ��ġ���� ������?
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePos;
    [SerializeField] float Delay = 1f;
    [Header("data")] //���ݷ��� �ʿ�? -> ��� ������ ����?
    [SerializeField] int hp = 100;

    public GameObject effectfab;
    GameObject target;
    Animator anim;
     
    void Start()
    {
        //�ʱⰪ����
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");

        //�߻��ϴ� �� (�ڵ��ã�� ��� - �ڽ�)
        firePos = transform.Find("FirePos");

        //�ݺ��ϴ� �Ѿ˹߻�
        InvokeRepeating("CreateBullet", 5, Delay);
    }

    void CreateBullet()
    {
        //�Ѿ˻���
        Instantiate(bulletPrefab, firePos.position, Quaternion.identity);
    } 

    void Update()
    {
        Animation(); //�ִϸ��̼�

        Move(); //�̵�
    }

    void Animation()
    {
        //������ ���� �̿��� �ִϸ��̼� ó��
        //�÷��̾ ��� �����ʿ� �ִ��� üũ ���� �ִϸ��̼� �ٲٱ�
        //�� ���� ���� �ִ� �ִϸ��̼��� ª�� -> �ذ�
        Vector3 dir = target.transform.position - transform.position;

        if (dir.x > 0.5f)
        {
            //+ ���������� ������
            anim.SetBool("Right", true);
        }
        else
        {
            anim.SetBool("Right", false);
        }
        if (dir.x < 0.5f)
        {
            anim.SetBool("Left", true);

            if (dir.x >= -0.3f) // ���� �ִϸ��̼�
            {
                anim.SetBool("Left", false);
            }
        }
        else
        {
            anim.SetBool("Left", false);
        }
    }

    void Move()
    {
        // �÷��̾�� �Ÿ��� �ΰ� �ʹ�
        float d = Vector2.Distance(transform.position, target.transform.position);

        if (length <= d)
        {
            //�̵�
            //�� Ÿ�� ��ġ�� ���� ������ ��ġ�� ���� �߻� -> ��� �ؾ��ұ�? (Layer�浹ó���� -> �״�� �÷��̾�� ����.. �׷�?)
            //transform.position = Vector3.Lerp(transform.position, target.transform.position, speed);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }
    }

    //�÷��̾� ���ݿ� ���� ������
    public void Damage(int attack)
    {
        hp -= attack;

        if(hp < 0)
        {
            DestroyEffect();
            Destroy(gameObject);
        }
    }

    //���� ����
    void DestroyEffect()
    {
        GameObject go = Instantiate(effectfab, transform.position, Quaternion.identity);
    }
}
