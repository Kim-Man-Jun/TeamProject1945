using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_Monster06 : MonoBehaviour
{
    public GameObject Monster06;
    public float StartTime = 1;
    public float spawnStop = 2;
    bool swi = true;

    void Start()
    {
        StartCoroutine("Delayed_Tank");
        StartCoroutine("Stop");
    }

    IEnumerator CreateTank()
    {
        yield return new WaitForSeconds(StartTime);
        float createX = Random.Range(0, 2);
        Vector2 r = new Vector2(createX, transform.position.y);
        Instantiate(Monster06, r, Quaternion.identity);
        swi=true;
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds (spawnStop);
        swi = false;
    }


    IEnumerator Delayed_Tank()
    {
        yield return new WaitForSeconds(31);
        StartCoroutine("CreateTank");
    }

    void Update()
    {
        
    }
}
