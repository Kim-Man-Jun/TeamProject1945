using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_Rotate_Attack : MonoBehaviour
{
    [SerializeField]

    public GameObject Item = null;
    public GameObject H_Bullet;
    public float Delay = 0.5f;
    public float moveSpeed = 1f;
    public int HP = 120;
    public float drop = 58f;


    public void LeftLaunch()
    {
        if (!IsInvoking("ShootLeft"))
        {
            Invoke("ShootLeft", Delay);
        }
    }

    public void DownLaunch()    //�Ʒ�
    {
        if (!IsInvoking("ShootDown"))
        {
            Invoke("ShootDown", Delay);
        }
    }

    public void RightRaunch()
    {
        if (!IsInvoking("ShootRight"))
        {
            Invoke("ShootRight", Delay);
        }
    }

    private void ShootLeft()
    {
        GameObject rotATK = Instantiate(H_Bullet, transform.position, Quaternion.identity);
        rotATK.GetComponent<WJ_AniBullet>().B_move(new Vector2(-1, -1));
    }
    private void ShootDown()
    {
        GameObject rotATK = Instantiate(H_Bullet, transform.position, Quaternion.identity);
        rotATK.GetComponent<WJ_AniBullet>().B_move(new Vector2(0, -1));

    }
    private void ShootRight()
    {
        GameObject rotATK = Instantiate(H_Bullet, transform.position, Quaternion.identity);
        rotATK.GetComponent<WJ_AniBullet>().B_move(new Vector2(1, -1));  
    }

    private void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
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
    public void ItemDrop()
    {
        float randomValue = Random.Range(0f, 100f);
        if (randomValue <= drop)
        {
            Instantiate(Item, transform.position, Quaternion.identity);
        }
    }
}
