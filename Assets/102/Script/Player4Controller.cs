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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            CurHp--;
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
