using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Transform ms;
    public GameObject Mbullet;
    public GameObject Item = null;
    //
    public int HP = 25;
    public float moveSpeed = 2f;
    public float Delay = 1f;
    public float drop = 58f;

    void Start()
    {
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(Mbullet, ms.position, Quaternion.identity);
        Invoke("CreateBullet", Delay);
    }
    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    public void ItemDrop()
    {
        float randomValue = Random.Range(0f, 100f);
        if( randomValue <= drop)
        {
            Instantiate(Item, ms.position, Quaternion.identity);
        }
    }

    public void Damage(int Attack)
    {
        HP -= Attack;
        if(HP <= 0 )
        {
            ItemDrop();
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
