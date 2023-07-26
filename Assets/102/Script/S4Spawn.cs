using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S4Spawn : MonoBehaviour
{
    public float ss = -6.5f;   //몬스터 생성 x값 처음
    public float es = 6.5f;    //몬스터 생성 x값 끝
    public float StartTime = 1;  //시작
    public float SpawnStop = 10; //스폰끝내는 시간
    public GameObject monster;
    public GameObject monster2;
    public GameObject Boss;


    bool swi = true;
    bool swi2 = true;

    [SerializeField]
    //GameObject textBossWarning; //보스 등장 텍스트 오브젝트

    private void Awake()
    {
        //보스 등장 텍스트 비활성화
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

        //두번째 몬스터 코루틴
        StartCoroutine("RandomSpawn2");

        //30초뒤에 2번째 몬스터스폰을 멈추기
        Invoke("Stop2", SpawnStop + 20);



    }

    void Stop2()
    {
        swi2 = false;
        StopCoroutine("RandomSpawn2");

        Vector3 pos = new Vector3(0, 4f, 0);

        //textBossWarning.SetActive(true);
        //보스출현
        Instantiate(Boss, pos, Quaternion.identity);



    }
    //코루틴으로 랜덤하게 생성하기
    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            //1초마다
            yield return new WaitForSeconds(StartTime);
            //x값 랜덤
            float X = Random.Range(ss, es);
            //X값 랜덤값 y값 자기자신값
            Vector2 r = new Vector2(X, transform.position.y);
            //몬스터 생성
            Instantiate(monster, r, Quaternion.identity);
        }
    }
    //코루틴으로 랜덤하게 생성하기
    IEnumerator RandomSpawn2()
    {
        while (swi2)
        {
            //1초마다
            yield return new WaitForSeconds(StartTime + 2);
            //x값 랜덤
            float X = Random.Range(ss, es);
            //X값 랜덤값 y값 자기자신값
            Vector2 r = new Vector2(X, transform.position.y);
            //몬스터2 생성
            Instantiate(monster2, r, Quaternion.identity);
        }
    }


}
