using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    Animator anim;
    public GameObject[] bullet = null;
    public GameObject Pos2Bullet = null;
    public GameObject Pos3Bullet = null;
    public GameObject Dead_Effect;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    //
    public Transform Pos;
    public Transform Pos2;
    public Transform Pos3;
    //
    public int HP = 30;
    public int bPower = 0;
    public int pPower = 0;
    public float Delay = 1.0f;
    public float moveSpeed = 5;

    //
    private bool isPos2BulletEnalbed = false;
    private bool isPos3BulletEnalbed = false;
    private bool isDamage = true;
    private int bulletCount = 0;    //발사된 총알 개수 세는 변수

    void Start()
    {
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");


        if (Input.GetAxis("Horizontal") >= 0.3f)
            anim.SetBool("Right", true);
        else anim.SetBool("Right", false);
        if (Input.GetAxis("Horizontal") <= -0.3f)
            anim.SetBool("Left", true);
        else anim.SetBool("Left", false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet[bPower], Pos.position, Quaternion.identity);
            bulletCount++;

            if (isPos2BulletEnalbed && isPos3BulletEnalbed && bulletCount >= 5)    //5발 발사후 pos2발사
            {
                Instantiate(Pos2Bullet, Pos2.position, Quaternion.identity);
                Instantiate(Pos3Bullet, Pos3.position, Quaternion.identity);
                bulletCount = 0;    //발사후 초기화
            }
            else Instantiate(bullet[bPower], Pos.position, Quaternion.identity);
        }

        if (transform.position.x >= 2.8f)
            transform.position = new Vector3(2.8f, transform.position.y, 0);
        if (transform.position.x <= -2.8f)
            transform.position = new Vector3(-2.8f , transform.position.y, 0);
        if (transform.position.y >= 4.6f)
            transform.position = new Vector3(transform.position.x, 4.4f, 0);
        if (transform.position.y <= -4.6f)
            transform.position = new Vector3(transform.position.x, -4.4f, 0);

        transform.Translate(moveX, moveY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            bPower += 1;

            if(bPower >= 6)
            {
                bPower = 6;
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Item3")
        {
            isPos2BulletEnalbed = true;
            isPos3BulletEnalbed = true;
            Destroy(collision.gameObject);
        }
    }

    public void Damage(int m_Attack)
    {
        HP -= m_Attack;
        if (HP <= 0)
        {
            Instantiate(Dead_Effect,transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {

        }
    }

    void OnDamaged(Vector2 targetPos)
    {
        gameObject.layer = 8;
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);

        int dirc = transform.position.x - targetPos.x > 0 ? 1 : -1;
        rb.AddForce(new Vector2(dirc,1)*7, ForceMode2D.Impulse);
    }
}
