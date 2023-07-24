using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;

    public GameObject bullet;
    public GameObject Dead_Effect;
    public Transform Pos;
    //
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
            Instantiate(bullet, Pos.position, Quaternion.identity);
        }

        if (transform.position.x >= 2.8f)
            transform.position = new Vector3(2.8f, transform.position.y, 0);
        if (transform.position.x <= -2.8f)
            transform.position = new Vector3(-2.8f , transform.position.y, 0);
        if (transform.position.y >= 4.6f)
            transform.position = new Vector3(transform.position.x, 4.6f, 0);
        if (transform.position.y <= -4.6f)
            transform.position = new Vector3(transform.position.x, -4.6f, 0);

        transform.Translate(moveX, moveY, 0);
    }
}
