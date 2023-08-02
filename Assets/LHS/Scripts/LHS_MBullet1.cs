using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//처음 발사할때 플레이어를 찾아 그 방향대로 이동하고 싶다.
public class LHS_MBullet1 : MonoBehaviour
{
    [SerializeField] float speed = 3;
    public int attack = 10;

    GameObject target;
    Vector3 dir;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        //초기값
        dir = (target.transform.position - transform.position).normalized;
    }
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    //플레이어와 충돌하면 플레이어 점수 깎임
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //플레이어 체력 깎기
            collision.gameObject.GetComponent<LHS_Player2Move>().Damage(attack);
            Destroy(gameObject);
            Debug.Log("플레이어 충돌");
        }
    }
}
