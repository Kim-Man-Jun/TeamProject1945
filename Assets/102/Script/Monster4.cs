using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster4 : MonoBehaviour
{
    public float HP;
    public float Speed;
    public GameObject Bullet;
    public GameObject HomingBullet;
    public GameObject ItemLifeUp;
    public GameObject HomingAmmo;
    public GameObject mijung;

    public Transform BulletPos;
    public Transform BulletPos2;
    public int Delay = 3;
    void Start()
    {

        //한번 호출
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(Bullet, BulletPos.position, Quaternion.identity);
   
        Invoke("CreateBullet", Delay);
    }

    void Update()
    {
        //아래방향으로 움직여라
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }



    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }



    public void ItemDrop()
    {
        int ItemRan = Random.Range(0, 3);
        //아이템 생성
        if(ItemRan == 0) 
        {
            Instantiate(ItemLifeUp, transform.position, Quaternion.identity);
        }
        if (ItemRan == 1)
        {
            Instantiate(HomingAmmo, transform.position, Quaternion.identity);
        }
        if (ItemRan == 2)
        { 
            Instantiate(mijung, transform.position, Quaternion.identity);
        }
        
    }


    //미사일에 따른 데미지 입는 함수
    public void Damage(int attack)
    {
        HP -= attack;

        if (HP <= 0)
        {
            int dropPer = Random.Range(0, 100);
            if(dropPer > 50)
            { 
            ItemDrop();
            }
            Destroy(gameObject);
        }
    }
}
