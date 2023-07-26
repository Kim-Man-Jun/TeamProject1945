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

        //�ѹ� ȣ��
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(Bullet, BulletPos.position, Quaternion.identity);
   
        Invoke("CreateBullet", Delay);
    }

    void Update()
    {
        //�Ʒ��������� ��������
        transform.Translate(Vector2.down * Speed * Time.deltaTime);
    }



    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }



    public void ItemDrop()
    {
        int ItemRan = Random.Range(0, 3);
        //������ ����
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


    //�̻��Ͽ� ���� ������ �Դ� �Լ�
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
