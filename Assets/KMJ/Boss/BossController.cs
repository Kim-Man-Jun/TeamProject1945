using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    //���� ü�� ����ä
    public static float BossNowHp;
    public float BossMaxHp = 20000;
    public Image BossNowHpBar;

    //���� ź�� ����
    public GameObject Bullet1;
    public GameObject Bullet2;

    //���� �߻籸 ����
    public Transform FirePos1 = null;
    public Transform FirePos2 = null;
    public Transform FirePos3 = null;
    public Transform FirePos4 = null;

    //���� ������ ����Ʈ
    public GameObject BoomEffect;

    //������ �븮�� ���
    public Transform PlayerPos;

    //ź�� ��Ÿ�� �ֱ�
    float curTime = 0;
    float curTime2 = 0;
    float curTime3 = 0;

    float Delay = 0;

    public float BulletSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        BossNowHp = BossMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        //���� ü�� ����
        BossNowHpBar.fillAmount = (float)BossNowHp / (float)BossMaxHp;

        //�� �̵����� �ɱ�
        if (transform.position.x <= -1.9f)
        {
            transform.position = new Vector3(-1.9f, transform.position.y, 0);
        }
        if (transform.position.x >= 1.9f)
        {
            transform.position = new Vector3(1.9f, transform.position.y, 0);
        }

        //�Ϲ��� ȣ�� ź��
        if (BossNowHp <= 20000 && BossNowHp > 18000)
        {
            //1�� pos �����̻��� �߻�
            curTime += Time.deltaTime;

            if (curTime >= 0.7f)
            {
                BossHoming();
                curTime = 0;
            }

            //2�� pos �����̻��� �߻�
            curTime2 += Time.deltaTime;

            if (curTime2 >= 0.9f)
            {
                BossHoming();
                curTime2 = 0;
            }
        }

        //��ä�÷� ��� ź��
        if (BossNowHp <= 18000 && BossNowHp > 12000)
        {
            //FirePos 3�� �߻� 360��
            curTime += Time.deltaTime;

            if (curTime >= 0.5f)
            {
                List<Transform> Bullets = new List<Transform>();

                for (int i = 0; i < 360; i += 20)
                {
                    if ((i >= 340 && i < 360) || (i >= 0 && i <= 40))
                    {
                        GameObject go = Instantiate(Bullet1);

                        go.transform.position = FirePos3.position;

                        Destroy(go, 2f);

                        Bullets.Add(go.transform);

                        go.transform.rotation = Quaternion.Euler(0, 0, i);
                    }
                }
                curTime = 0;
            }

            //FirePos 4�� �߻� 360��
            curTime2 += Time.deltaTime;

            if (curTime2 >= 0.5f)
            {
                List<Transform> Bullets = new List<Transform>();

                for (int i = 0; i < 360; i += 20)
                {
                    if ((i >= 340 && i < 360) || (i >= 0 && i <= 40))
                    {
                        GameObject go = Instantiate(Bullet1);

                        go.transform.position = FirePos4.position;

                        Destroy(go, 2f);

                        Bullets.Add(go.transform);

                        go.transform.rotation = Quaternion.Euler(0, 0, i);
                    }
                }
                curTime2 = 0;
            }
        }

        //360�� ź���� �幮�幮 ��� ȣ��ź��
        if (BossNowHp <= 12000 && BossNowHp > 6000)
        {
            //FirePos 3�� �߻� ��������
            FirePos3.transform.Rotate(Vector3.forward * 300 * Time.deltaTime);

            curTime += Time.deltaTime;

            if (curTime >= 0.05f)
            {
                GameObject go = Instantiate(Bullet1);
                go.transform.position = FirePos3.position;
                go.transform.rotation = FirePos3.rotation;
                curTime = 0;
            }

            //FirePos 4�� �߻� 360��
            curTime2 += Time.deltaTime;

            if (curTime2 >= 0.7f)
            {
                List<Transform> Bullets = new List<Transform>();

                for (int i = 0; i < 360; i += 10)
                {
                    GameObject go = Instantiate(Bullet1);

                    go.transform.position = FirePos4.position;

                    Destroy(go, 2f);

                    Bullets.Add(go.transform);

                    go.transform.rotation = Quaternion.Euler(0, 0, i);
                }
                curTime2 = 0;
            }

            //FirePos 1�� �߻� ���� ȣ�� �̻���
            curTime3 += Time.deltaTime;

            if (curTime3 >= 2.5f)
            {
                BossHoming();
                curTime3 = 0;
            }
        }

        //360�� �� ���� �����ϴ� ź������(������ �ȵ�)
        if (BossNowHp <= 6000)
        {
            curTime += Time.deltaTime;

            if (curTime >= 2f)
            {
                List<Transform> Bullets = new List<Transform>();

                for (int i = 0; i < 360; i += 13)
                {
                    GameObject go = Instantiate(Bullet1);

                    go.transform.position = FirePos3.position;

                    Destroy(go, 2f);

                    Bullets.Add(go.transform);

                    go.transform.rotation = Quaternion.Euler(0, 0, i);
                }

                StartCoroutine(BulletToTarget(Bullets));
                curTime = 0;
            }
        }
    }

    //�����̻��� �߻�
    void BossHoming()
    {
        Instantiate(Bullet2, FirePos1.position, Quaternion.identity);
    }

    IEnumerator BulletToTarget(IList<Transform> objects)
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("!!!!!!!");
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].transform.Translate(Vector3.zero);

            Vector2 dir = PlayerPos.transform.position
                - objects[i].transform.position;

            Vector2 dirNo = dir.normalized;

            objects[i].transform.Translate(dirNo * BulletSpeed * Time.deltaTime);
        }

        objects.Clear();
    }


    public void Damage(int attack)
    {
        BossNowHp -= attack;

        if (BossNowHp <= 0)
        {
            BossNowHpBar.fillAmount = 0;
            Destroy(gameObject);
        }
    }       //���� ������ �̺�Ʈ ó��

    private void OnDestroy()
    {
        GameObject go = Instantiate(BoomEffect, transform.position, Quaternion.identity);
        Destroy(go, 0.5f);
    }               //������Ʈ�� ������ ó��
}
