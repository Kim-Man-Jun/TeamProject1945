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
        //플레이어 태그로 찾기
        target = GameObject.FindGameObjectWithTag("Monster");
       
        target = GameObject.FindGameObjectWithTag("Boss");

        //A - B   플레이어 - 미사일    
        dir = target.transform.position - transform.position;
        //방향벡터만 구하기 단위벡터 1의크기로 만든다.
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
            //플레이어 지우기
            // Destroy(collision.gameObject);
            //미사일 지우기
            collision.gameObject.GetComponent<Monster4>().Damage(Attack);
            Destroy(gameObject);
        }
    }
}
