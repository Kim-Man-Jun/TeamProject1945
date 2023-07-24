using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    public float Speed = 2f;

    public GameObject[] Bullet;

    public Transform pos1 = null;
    public Transform pos2 = null;
    public Transform pos3 = null;

    public int WeaponPower = 0;
    public static int Bomb = 3;

    public GameObject BoomEffect;

    public float CoolTime;
    public float CoolTimestatic = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾� ������ ����
        float moveX = Speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = Speed * Time.deltaTime * Input.GetAxis("Vertical");

        transform.Translate(moveX, moveY, 0);

        //�÷��̾� �ִϸ��̼� ����
        if (Input.GetAxis("Vertical") >= 0)
        {
            if (Input.GetAxis("Horizontal") >= 0.3f)
            {
                animator.Play("Right");
            }
            else if (Input.GetAxis("Horizontal") <= -0.3f)
            {
                animator.Play("Left");
            }
            else
            {
                animator.Play("Idle");
            }
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            if (Input.GetAxis("Horizontal") >= 0.3f)
            {
                animator.Play("Left");
            }
            else if (Input.GetAxis("Horizontal") <= -0.3f)
            {
                animator.Play("Right");
            }
            else
            {
                animator.Play("Idle");
            }
        }

        //�� �̵����� �ɱ�
        if (transform.position.x <= -2.5f)
        {
            transform.position = new Vector3(-2.5f, transform.position.y, 0);
        }
        if (transform.position.x >= 2.5f)
        {
            transform.position = new Vector3(2.5f, transform.position.y, 0);
        }
        if (transform.position.y >= -14)
        {
            transform.position = new Vector3(transform.position.x, -14f, 0);
        }
        if (transform.position.y <= -23.2f)
        {
            transform.position = new Vector3(transform.position.x, -23.2f, 0);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            if (CoolTime == 0)
            {
                if (WeaponPower == 0)
                {
                    Instantiate(Bullet[WeaponPower], pos1.position, Quaternion.identity);
                    CoolTime = CoolTimestatic;
                }
                else if (WeaponPower == 1)
                {
                    Instantiate(Bullet[WeaponPower], pos1.position, Quaternion.identity);
                    CoolTime = CoolTimestatic;
                }
                else if (WeaponPower == 2)
                {
                    Instantiate(Bullet[WeaponPower], pos1.position, Quaternion.identity);
                    Instantiate(Bullet[WeaponPower - 1], pos2.position, Quaternion.identity);
                    Instantiate(Bullet[WeaponPower - 1], pos3.position, Quaternion.identity);
                    CoolTime = CoolTimestatic;
                }
                else if (WeaponPower == 3)
                {
                    Instantiate(Bullet[WeaponPower], pos1.position, Quaternion.identity);
                    Instantiate(Bullet[WeaponPower - 1], pos2.position, Quaternion.identity);
                    Instantiate(Bullet[WeaponPower - 1], pos3.position, Quaternion.identity);
                    CoolTime = CoolTimestatic;
                }
            }

            CoolTime -= Time.deltaTime;

            if (CoolTime < 0)
            {
                CoolTime = 0;
            }
        }
    }
}
