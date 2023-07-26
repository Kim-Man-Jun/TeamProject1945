using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    public GameObject[] bullet = null;
    public GameObject Dead_Effect;
    public Transform Pos;
    //
    public int HP = 30;
    public int power = 0;
    public float moveSpeed = 5;
   
    //
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
            Instantiate(bullet[power], Pos.position, Quaternion.identity);
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
            power += 1;

            if(power >= 3)
            {
                power = 3;
            }

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
    }
}
