using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//ó�� �߻��Ҷ� �÷��̾ ã�� �� ������ �̵��ϰ� �ʹ�.
public class LHS_MBullet1 : MonoBehaviour
{
    [SerializeField] float speed = 3;
    public int attack = 10;

    GameObject target;
    Vector3 dir;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");

        //�ʱⰪ
        dir = (target.transform.position - transform.position).normalized;
    }
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }

    //�÷��̾�� �浹�ϸ� �÷��̾� ���� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //�÷��̾� ü�� ���
            collision.gameObject.GetComponent<LHS_Player2Move>().Damage(attack);
            Destroy(gameObject);
            Debug.Log("�÷��̾� �浹");
        }
    }
}
