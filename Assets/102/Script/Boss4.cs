using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    IEnumerator Pt3;

    void Start()
    {
        Pt1 = Pattern1();
        Pt2 = CircleFire();
        Pt3 = Pattern3();
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
        
        if(PatternTime == 30) 
        {
            StopCoroutine(Pt2);
            StartCoroutine(Pt3);
        }
        Invoke("TimeCount", 1);
        if (PatternTime == 40)
        {
            StopCoroutine(Pt3);
            StartCoroutine(Pt1);
            isPattern1 = true;
        }
    }
  
    IEnumerator Pattern1()
    { 
        float attackrate = 0.5f;
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
        float attackRate = 5;//�����ֱ�
        int count = 10;    //�߻�ü ���� ����
        float intervalAngle = 360 / count;  //�߻�ü ������ ����
        float weightAngle = 0; //���ߵǴ� ���� (�׻� ���� ��ġ�� �߻����� �ʵ��� ����)


        //�� ���·� ����ϴ� �߻�ü ���� (count ���� ��ŭ)
        while (true)
        {
            for (int i = 0; i < count; ++i)
            {
                //�߻�ü ����
                GameObject clone = Instantiate(BouncyBullet, transform.position, Quaternion.identity);
                //�߻�ü �̵� ����(����)
                float angle = weightAngle + intervalAngle * i;
                //�߻�ü �̵� ���� (����)
                //Cos(����), ���� ������ ���� ǥ���� ���� PI/180�� ����
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //Sin(����), ���� ������ ���� ǥ���� ���� PI/180�� ����
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);
                //�߻�ü �̵� ���� ����
                clone.GetComponent<BouncyBullet4>().Move(new Vector2(x, y));
            }
            //�߻�ü�� �����Ǵ� ���� ���� ������ ���� ����
            weightAngle += 3;

            //attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate); //3�ʸ��� ���� �̻��� �߻�

        }
    }

    IEnumerator Pattern3()
    {
        float atkRate = 1f;
        float p3angle = 180;
        float p3angle2 = 90f;
        BulletPos.transform.rotation = Quaternion.identity;
        BulletPos1.transform.rotation = Quaternion.identity;
        BulletPos2.transform.rotation = Quaternion.identity;

        while (true) 
        {
            Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
            Instantiate(Bullet, BulletPos1.transform.position, BulletPos1.transform.rotation);
            Instantiate(Bullet, BulletPos2.transform.position, BulletPos2.transform.rotation);

            BulletPos.Rotate(0, 0, 3);
            BulletPos1.Rotate(0, 0, p3angle);
            BulletPos2.Rotate(0, 0, p3angle2);
            yield return new WaitForSeconds(atkRate);
        }
       
    }
    void CreateBullet()
    {
        Instantiate(Bullet, BulletPos.transform.position, BulletPos.transform.rotation);
    }
}
