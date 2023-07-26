using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4Bullet : MonoBehaviour
{
    public float Speed = 4.0f;
    public int Attack = 10;
    public GameObject effect;



    void Update()
    {
        //�̻����� ���ʹ������� �����δ�.
        transform.Translate(Vector2.up * Speed * Time.deltaTime);

        if (Time.timeScale == 0.5f)
        {
            Speed = 8.0f;
        }
        if (Time.timeScale == 1f)
        {
            Speed = 4.0f;
        }
        Destroy(gameObject, 0.8f);
    }










    //�ش��ڵ带 �����Ͻÿ�.
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }








    // public GameObject effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Monster")
        {
            //������ �Լ�ȣ��
            //collision.gameObject.GetComponent<Monster>().ItemDrop();

            ////���� �浹 �����
            //Destroy(collision.gameObject);

            collision.gameObject.GetComponent<Monster4>().Damage(Attack);


            //����Ʈ �����ϱ�
            //GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //����Ʈ 1�ʵڿ� �����
            //Destroy(go, 1);


            //�̻��� �����
            Destroy(gameObject);


        }


        if (collision.CompareTag("Boss"))
        {
            //����Ʈ �����ϱ�
          //  GameObject go = Instantiate(effect, transform.position, Quaternion.identity);
            //����Ʈ 1�ʵڿ� �����
            //Destroy(go, 1);


            //�̻��� ����
            Destroy(gameObject);

        }


    }

}
