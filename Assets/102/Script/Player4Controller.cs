using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player4Controller : MonoBehaviour
{
    public float Speed;

    public int MaxHp;
    public int CurHp;
    public bool isDead = false;
    public GameObject ammo;
    public GameObject HomingAmmo;
    public bool isItem = false;
    public Transform BulletPos;
    public int Hac;
    Animator ani;
    public bool isDamaged = false;
    public bool isNoHit = false;
    public float noHitTime = 0; 
    float overTime = 0;
    void Start()
    {
        CurHp = MaxHp;
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = Speed * Time.deltaTime * Input.GetAxis("Vertical");

        if (Input.GetAxis("Horizontal") >= 0.5f)
        {
            ani.SetBool("right", true);
        }
        else
        {
            ani.SetBool("right", false);
        }

        if (Input.GetAxis("Horizontal") <= -0.5f)
        {
            ani.SetBool("left", true);
        }
        else
        {
            ani.SetBool("left", false);
        }


        transform.Translate(moveX, moveY, 0);
        
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            GeneralFire();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            HomingFire();
            
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 0.5f;
            Speed = 20;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1f;
            Speed = 10;
        }

        if (transform.position.x >= 8.6f)
            transform.position = new Vector3(8.6f, transform.position.y, 0);
        if (transform.position.x <= -8.6f)
            transform.position = new Vector3(-8.6f, transform.position.y, 0);
        if (transform.position.y >= 4.3f)
            transform.position = new Vector3(transform.position.x,4.3f , 0);
        if (transform.position.y <= -4.3f)
            transform.position = new Vector3(transform.position.x,-4.3f, 0);
        Dead();
        if(isDead == true) 
        {
            overTime += Time.deltaTime;
        }
        if (isDamaged == true)
        {
            noHitTime += Time.deltaTime;
            if (noHitTime >= 1)
            {
                isNoHit = false;
                noHitTime = 0;
                isDamaged = false;
            }
        }
    }
    void GeneralFire()
    {
        Instantiate(ammo, transform.position, Quaternion.identity);
    }

    void HomingFire()
    {
      
        if (isItem == true) { 
        Instantiate(HomingAmmo, transform.position, Quaternion.identity);
            Hac--;
            if (Hac == 0)
            { 
                isItem = false;
            }
        }
        
    }

    void Dead()
    {
        
        if (CurHp <= 0)
        {
            ani.SetBool("Dead", true);
            Destroy(gameObject, 1);
            isDead = true;
            if (overTime >= 2)
            {
                Time.timeScale = 0.0f;
            }


        }
    }
    void SetDamage()
    {
        CurHp--;
        isDamaged = true;
        isNoHit = true;
       

    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            if(isNoHit == false) 
            { 
            SetDamage();
            }
        }
        if (collision.CompareTag("Boss"))
        {
            if (isNoHit == false)
            {
                SetDamage();
            }
        }

        if (collision.CompareTag("EnemyBullet"))
        {
            if (isNoHit == false)
            {
                SetDamage();
            }
        }
        if (collision.CompareTag("Item"))
        {
          
          
            if (CurHp == MaxHp)
            {
                CurHp = MaxHp;
            }
            else 
            {
                CurHp++;
            }
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Item1"))
        {
            isItem = true;
            Hac = 50;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Item2"))
        {

        }

    }
}
