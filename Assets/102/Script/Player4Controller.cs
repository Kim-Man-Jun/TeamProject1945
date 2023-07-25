using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Controller : MonoBehaviour
{
    public float Speed;
    public float atk;
    public int MaxHp;
    public int CurHp;
    public bool isDead = false;
    public GameObject ammo;
    public bool isItem = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Speed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = Speed * Time.deltaTime * Input.GetAxis("Vertical");
        
       // if(Input.GetAxisRaw("Horizontal"))
        
        transform.Translate(moveX, moveY, 0);

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
}
