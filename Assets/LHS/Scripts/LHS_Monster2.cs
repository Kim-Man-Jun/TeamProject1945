using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Ʒ��θ� �̵��ϴ� ��
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
        //�÷��̾�� �ױ�
        if(collision.gameObject.CompareTag("Player"))
        {
            //�÷��̾� ü�� ���
            collision.gameObject.GetComponent<LHS_Player2Move>().Damage(attack);
            Debug.Log("�÷��̾� �浹");
        }
    }

    public void Damage(int attack)
    {
        hp -= attack;

        if(hp <= 0)
        {
            //������ ���� ��
            Instantiate(item, transform.position, Quaternion.identity);

            //�ױ�
            Destroy(gameObject);
        }
    }
}
