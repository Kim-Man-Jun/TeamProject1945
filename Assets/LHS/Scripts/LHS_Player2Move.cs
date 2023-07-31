using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//�̵�, �ִϸ��̼�
//�Ѿ˹߻�
public class LHS_Player2Move : MonoBehaviour
{
    //�̵��ӵ�
    [Header("�̵��ӵ�")]
    [SerializeField] float moveSpeed = 5f;
    //�Ѿ˰���
    [Header("�Ѿ�������")]
    [SerializeField] GameObject bulletFactory;
    public int hp = 100;

    GameObject bullet1;
    GameObject bullet2;
    
    Animator anim;
    
    //player������ 
    public bool startGame = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        Intro();

        #region Linecast Test
        //Linecast -> �׽�Ʈ���̶�� �׸��Ⱑ ����?
        //Linecast ���̸�ŭ ���� �׸���? �ƴ� ������ �ɷ� ���� �� �׸���? 
        //Rotate�� ���� �� �ֳ�?
        Physics2D.Linecast(transform.position, transform.position + (transform.up * 1.5f));
        Debug.DrawLine(transform.position, transform.position + (transform.up * 1.5f));
        #endregion
        
        Move();

        //�Ѿ˰��� -> �� �տ� ������ ���´�.
        // = Input.GetKeyDown(KeyCode.Space)
        if (Input.GetButtonDown("Jump")) //�ص��ƿ��������� �ѹ� �� �߻� ���ϰ�
        {
            
            if(bullet1 == null)
            {
                //��..! �ڵ庯���ؾ���
                /*for(int i = 0; i < 2; i++)
                {
                    bullet = Instantiate(bulletFactory,transform.position, Quaternion.identity); 
                }*/

                bullet1 = Instantiate(bulletFactory, transform.position, Quaternion.identity); 

            }

            LHS_Player2Bullet.isReturning = true;
        }
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float moveX = h * moveSpeed * Time.deltaTime;
        float moveY = v * moveSpeed * Time.deltaTime;

        if (startGame == true)
        {
            #region �ִϸ��̼� ����
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

            #region �̵�
            //������ ��� ������� �ϰ����� �ӵ��� �����Ű�� ���ؼ��� 
            //������ ũ�⸦ 1�� �ٲ��ִ� normalized�� Ȱ�� -> �밢���̵�
            //���1
            /*Vector3 dir = new Vector3(h, v, 0);
            dir.Normalize();
            transform.position += dir * moveSpeed * Time.deltaTime;*/

            //���2
            //���� ���� �Ŀ��� ������ ����
            transform.Translate(new Vector3(h, v, 0).normalized * moveSpeed * Time.deltaTime);

            //�̵� ���� x�� 2.45
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
    }

    void Intro()
    {
        if (startGame == false)
        {
            //�����Ҷ� ���� ��ġ�� �̵� //���ڷ� �Ҽ��� �ְ�, ��ġ ������ ����
            //���� ���� ���� �̵�����
            Vector3 endPos = new Vector3(0, -4, 0);

            //��������, ��ǥ����, �̵��ӵ�
            transform.position = Vector3.MoveTowards(transform.position, endPos, 0.02f);

            if (transform.position == endPos)
            {
                startGame = true;
            }
        }
    }
    
    public void Damage(int attack)
    {
        hp -= attack;

        if(hp < 0)
        {
            //���� ����
            Debug.Log("���� ����");
        }
    }
}
