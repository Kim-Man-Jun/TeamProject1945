using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnegyBoltControl : MonoBehaviour
{
    public GameObject Target_Player;

    public float Speed = 5f;
    Vector2 dir;
    Vector2 dirNo;
    public GameObject BoomEffect;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Target_Player = GameObject.FindGameObjectWithTag("Player");
        dir = Target_Player.transform.position - transform.position;
        dirNo = dir.normalized;

        rb.AddForce(dirNo * Speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
