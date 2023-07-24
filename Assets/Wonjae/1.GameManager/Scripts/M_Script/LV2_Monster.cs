using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV2_Monster : MonoBehaviour
{
    public GameObject Player_Death;
    public float moveSpeed = 5f;
    public int HP = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveY = moveSpeed * Time.deltaTime;
        transform.Translate(0, -moveY, 0);
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
}
