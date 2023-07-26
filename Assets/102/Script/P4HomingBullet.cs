using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P4HomingBullet : MonoBehaviour
{
    public GameObject target;
    public float Speed = 4f;
    Vector2 dir;
    Vector2 dirNo;
    public int Attack = 30;



    // Start is called before the first frame update
    void Start()
    {
        //�÷��̾� �±׷� ã��
        target = GameObject.FindGameObjectWithTag("Monster");
       
        target = GameObject.FindGameObjectWithTag("Boss");

        //A - B   �÷��̾� - �̻���    
        dir = target.transform.position - transform.position;
        //���⺤�͸� ���ϱ� �������� 1��ũ��� �����.
        dirNo = dir.normalized;


    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0.5f)
        {
            Speed = 8.0f;
        }
        if (Time.timeScale == 1f)
        {
            Speed = 4.0f;
        }
        transform.Translate(dirNo * Speed * Time.deltaTime);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            //�÷��̾� �����
            // Destroy(collision.gameObject);
            //�̻��� �����
            collision.gameObject.GetComponent<Monster4>().Damage(Attack);
            Destroy(gameObject);
        }
    }
}
