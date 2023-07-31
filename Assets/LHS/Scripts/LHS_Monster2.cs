using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//아래로만 이동하는 적
public class LHS_Monster2 : MonoBehaviour
{
    public float speed = 5f;
    public int hp = 50;
    public int attack = 20;

    [SerializeField] GameObject item;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //플레이어면 죽기
        if(collision.gameObject.CompareTag("Player"))
        {
            //점수 깎기
        }
    }

    public void Damage(int attack)
    {
        hp -= attack;

        if(hp < 0)
        {
            //아이템 생성 후
            Instantiate(item, transform.position, Quaternion.identity);

            //죽기
            Destroy(gameObject);
        }
    }
}
