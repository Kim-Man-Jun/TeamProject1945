using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4Spawn : MonoBehaviour
{
    public float ss = -6.5f;   //���� ���� x�� ó��
    public float es = 6.5f;    //���� ���� x�� ��
    public float StartTime = 1;  //����
    public float SpawnStop = 10; //���������� �ð�
    public GameObject monster;
    public GameObject monster2;
    public GameObject Boss;


    bool swi = true;
    bool swi2 = true;

    [SerializeField]
    //GameObject textBossWarning; //���� ���� �ؽ�Ʈ ������Ʈ

    private void Awake()
    {
        //���� ���� �ؽ�Ʈ ��Ȱ��ȭ
       // textBossWarning.SetActive(false);

    }


    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", SpawnStop);
    }

    void Stop()
    {
        swi = false;

        StopCoroutine("RandomSpawn");

        //�ι�° ���� �ڷ�ƾ
        StartCoroutine("RandomSpawn2");

        //30�ʵڿ� 2��° ���ͽ����� ���߱�
        Invoke("Stop2", SpawnStop + 20);



    }

    void Stop2()
    {
        swi2 = false;
        StopCoroutine("RandomSpawn2");

        Vector3 pos = new Vector3(0, 4f, 0);

        //textBossWarning.SetActive(true);
        //��������
        Instantiate(Boss, pos, Quaternion.identity);



    }
    //�ڷ�ƾ���� �����ϰ� �����ϱ�
    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            //1�ʸ���
            yield return new WaitForSeconds(StartTime);
            //x�� ����
            float X = Random.Range(ss, es);
            //X�� ������ y�� �ڱ��ڽŰ�
            Vector2 r = new Vector2(X, transform.position.y);
            //���� ����
            Instantiate(monster, r, Quaternion.identity);
        }
    }
    //�ڷ�ƾ���� �����ϰ� �����ϱ�
    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            //1�ʸ���
            yield return new WaitForSeconds(StartTime + 2);
            //x�� ����
            float X = Random.Range(ss, es);
            //X�� ������ y�� �ڱ��ڽŰ�
            Vector2 r = new Vector2(X, transform.position.y);
            //����2 ����
            Instantiate(monster2, r, Quaternion.identity);
        }
    }


}
