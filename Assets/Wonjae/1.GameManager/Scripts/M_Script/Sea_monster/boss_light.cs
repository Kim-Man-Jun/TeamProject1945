using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_light : MonoBehaviour
{
    public GameObject Player_Death;

    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(Player_Death, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
