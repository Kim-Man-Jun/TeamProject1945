using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float left_ss = -2.2f;
    public float right_es = 2.2f;

    public float StartTime = 1; //시작
    public float SpawnStop = 30;    //스폰 끝
    public float SpawnStop2 = 0;
    public GameObject Monster;
    public GameObject Monster2;
    public GameObject Monster3;

    bool swi = true;

    void Start()
    {
        StartCoroutine("RandomSpawn");
        StartCoroutine("DelayedRandomSpawn2");
        StartCoroutine("DelayedRandomSpawn3");
        StartCoroutine("Stop");
        StartCoroutine("Stop2");
        StartCoroutine("Stop3");
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(SpawnStop);
        swi = false;
    }

    IEnumerator Stop2()
    {
        yield return new WaitForSeconds(SpawnStop);
        swi = false;
    }

    IEnumerator Stop3()
    {
        yield return new WaitForSeconds(SpawnStop2);
        swi = false;
    }

    IEnumerator RandomSpawn()
    {
        while (swi)
        {
            yield return new WaitForSeconds(StartTime + 2);
            float createX = Random.Range(left_ss, right_es);
            Vector2 r = new Vector2(createX, transform.position.y);
            Instantiate(Monster, r, Quaternion.identity);
        }
    }

    IEnumerator RandomSpawn2()
    {
        while (swi)
        {
            yield return new WaitForSeconds(StartTime + 2);
            float createX = Random.Range(left_ss, right_es);
            Vector2 r = new Vector2(createX, transform.position.y);
            Instantiate(Monster2, r, Quaternion.identity) ;
        }
    }

    IEnumerator RandomSpawn3()
    {
        while (swi)
        {
            yield return new WaitForSeconds(StartTime + 8);
            float createX = Random.Range(left_ss, right_es);
            Vector2 r = new Vector2(createX, transform.position.y);
            Instantiate(Monster3, r, Quaternion.identity);
        }
    }

    IEnumerator DelayedRandomSpawn2()
    {
        while (swi)
        {
            yield return new WaitForSeconds(7);  
            StartCoroutine("RandomSpawn2");
        }
    }

    IEnumerator DelayedRandomSpawn3()
    {
        while (swi)
        {
            yield return new WaitForSeconds(10);    
            StartCoroutine("RandomSpawn3");
        }
    }

    void Update()
    {
        
    }
}
