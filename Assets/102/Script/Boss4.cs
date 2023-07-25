using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boss4 : MonoBehaviour
{
    public Transform BulletPos;
    public Transform BulletPos1;
    public Transform BulletPos2;
    public int HP;
    public GameObject Bullet;
    public GameObject BouncyBullet;
    public int PatternTime = 0;
    public bool isPattern1 = false;
    IEnumerator Pt1;
    IEnumerator Pt2;

    void Start()
    {
        Pt1 = Pattern1();
        Pt2 = CircleFire();
        StartCoroutine(Pt1);
        Invoke("TimeCount", 1);
      

    }

    // Update is called once per frame
    void Update()
    {
        if(isPattern1 == true)
        CreateBullet();
      
    }

    void TimeCount()
    {
        PatternTime++;
        if(PatternTime == 50)
            
        { 
            PatternTime = 0; 
        }
      

        if (PatternTime == 10)
        {
            StopCoroutine(Pt1);
            isPattern1 = false;
            StartCoroutine(Pt2);
        }
        
        //if(PatternTime == 30) 
        //{
        //    StopCoroutine(Pt2);
        //}
        Invoke("TimeCount", 1);
    }
  
    IEnumerator Pattern1()
    { 
        float attackrate = 0.2f;
        float angle = 3f;
        while (true)
        {
            isPattern1 = true;
           
            BulletPos.Rotate(0, 0, angle);
            
            Instantiate(Bullet, BulletPos1.transform.position, BulletPos1.transform.rotation);
            Instantiate(Bullet, BulletPos2.transform.position, BulletPos2.transform.rotation);
            
            BulletPos1.Rotate(0, 0, angle);
            BulletPos2.Rotate(0, 0, -angle);


            yield return new WaitForSeconds(attackrate);

          
        }
    }
    IEnumerator CircleFire()
    {
        float attackRate = 5;//공격주기
        int count = 30;    //발사체 생성 갯수
        float intervalAngle = 360 / count;  //발사체 사이의 각도
        float weightAngle = 0; //가중되는 각도 (항상 같은 위치로 발사하지 않도록 설정)


        //원 형태로 방사하는 발사체 생성 (count 개수 만큼)
        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                //발사체 생성
                GameObject clone = Instantiate(BouncyBullet, transform.position, Quaternion.identity);
                //발사체 이동 방향(각도)
                float angle = weightAngle + intervalAngle * i;
                //발사체 이동 방향 (벡터)
                //Cos(각도), 라디안 단위의 각도 표현을 위해 PI/180을 곱함
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //Sin(각도), 라디안 단위의 각도 표현을 위해 PI/180을 곱함
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);
                //발사체 이동 방향 설정
                clone.GetComponent<BouncyBullet4>().Move(new Vector2(x, y));
            }
            //발사체가 생성되는 시작 각도 설정을 위한 변수
            weightAngle += 1;

            //attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate); //3초마다 원형 미사일 발사

        }
    }

    void CreateBullet()
    {
        Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
    }
}
