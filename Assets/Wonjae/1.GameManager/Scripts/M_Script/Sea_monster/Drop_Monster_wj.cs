using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop_Monster_wj : MonoBehaviour
{
    public Transform ms1;
    public Transform ms2;
    public Transform ms3;
    public GameObject Drop_Bullet;
    public GameObject Drop_Ms_Bullet;
    public GameObject Item = null;
    public GameObject DeadBoss;
    //
    public int HP = 350;
    public int drop = 15;
    public int flag = 1;
    public float moveSpeed = 2.5f;
    public float delay = 2.0f;


    void Start()
    {
        Invoke("CreateBullet", delay);
        Invoke("CreateMS_Bullet", delay + 2);
    }

    void CreateBullet()
    {
        Instantiate(Drop_Bullet, ms1.transform.position, Quaternion.identity);
        Invoke("CreateBullet", delay); ;
    }

    void CreateMS_Bullet()
    {
        Instantiate(Drop_Ms_Bullet, ms2.transform.position,Quaternion.identity);
        Instantiate(Drop_Ms_Bullet, ms3.transform.position, Quaternion.identity);
        Invoke("CreateMS_Bullet", delay);
    }


    void Update()
    {
        if (transform.position.x >= 2.0f)
        {
            flag *= -1;
        }
        if (transform.position.x <= -2.0f)
        {
            flag *= -1;
        }

        transform.Translate(flag * moveSpeed * Time.deltaTime, 0, 0);
    }

    public void ItemDrop()
    {
        float randomValue = Random.Range(0f, 100f);
        if (randomValue <= drop)
        {
            Instantiate(Item, ms1.position, Quaternion.identity);
        }
    }

    public void Damage(int Attack)
    {
        HP -= Attack;
        if (HP <= 0)
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
