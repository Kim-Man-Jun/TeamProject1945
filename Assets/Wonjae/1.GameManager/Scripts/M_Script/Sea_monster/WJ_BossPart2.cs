using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_BossPart2 : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float startWaitTime;
    private float waitTime;
    public float StartTime = 1;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    //

    public int HP = 4000;

    public Transform moveSpot;
    public Transform Tooth_Pos;
    public Transform ms1;
    public Transform ms2;
    public Transform ms3;
    public Transform BuriMS;

    public GameObject Item = null;
    public GameObject BossExplosion;
    public GameObject L_thunder;
    public GameObject R_thunder;
    public GameObject tooth_Bullet;
    public GameObject Mbullet;
    public GameObject drill;

    GameObject Spot;
    Rigidbody2D rb;

    void Start()
    {
        Spot = GameObject.Find("MoveSpot");
        rb = GetComponent<Rigidbody2D>();
        Invoke("CreateBullet", 1);
        Invoke("CreateDrill", 7);
        StartCoroutine(CircleFire());
        Invoke("Thunder", 2f);
    }
    // Update is called once per frame
    //void Update()
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, moveSpot.position,
    //        moveSpeed * Time.deltaTime);
        
    //    if (Vector2.Distance(transform.position, moveSpot.position) < 0.2)
    //    {
    //        if (waitTime <= 0)
    //        {
    //            moveSpot.position = new Vector2(Random.Range(minX, maxX),Random.Range(minY, maxY));
    //            waitTime = startWaitTime;
    //        }
    //        else
    //        {
    //            waitTime -= Time.deltaTime;
    //        }
    //    }
    //}
    void CreateBullet()
    {
        Instantiate(Mbullet, ms3.position, Quaternion.identity);
        Invoke("CreateBullet", 1);
    }
    void CreateDrill()
    {
        Instantiate(drill, BuriMS.position, Quaternion.identity);
        Invoke("CreateDrill", 5);
    }

    //회전공격
    IEnumerator CircleFire()
    {
        
        float attackRate = 10f;
        int count = 40;
        float intervalAngle = 360 / count;
        float weightAngle = 120;

        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                GameObject clone = Instantiate(tooth_Bullet, transform.position, Quaternion.identity);

                float angle = weightAngle + intervalAngle * i;
                float x = Mathf.Cos(angle * Mathf.PI / 180.0f);
                float y = Mathf.Sin(angle * Mathf.PI / 180.0f);
                clone.GetComponent<rotate_bullet_wj>().Move(new Vector2(x, y));
            }
            weightAngle += 1;
            yield return new WaitForSeconds(attackRate);
        }
    }

    void Thunder()
    {   
            Instantiate(L_thunder, ms1.transform.position, Quaternion.identity);
            Instantiate(R_thunder, ms2.transform.position, Quaternion.identity);
            Invoke("Thunder", 8f);
    }

    public void Damage(int Attack)
    {
        HP -= Attack;
        if (HP <= 0)
        {
            Instantiate(BossExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
