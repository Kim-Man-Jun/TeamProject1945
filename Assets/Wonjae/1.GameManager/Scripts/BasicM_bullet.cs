using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicM_bullet : MonoBehaviour
{
    public GameObject target;
    public GameObject Player_Death;
    public float bSpeed = 3.0f;

    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        dir = target.transform.position - transform.position;
        dirNo = dir.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(Player_Death, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(dirNo * bSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
