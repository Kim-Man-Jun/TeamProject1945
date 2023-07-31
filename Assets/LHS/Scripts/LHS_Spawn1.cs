using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�ټ� �������� �߻��ϰ� ����
public class LHS_Spawn1 : MonoBehaviour
{
    //���� ���� x ��
    public float ss = -2; //����
    public float es = 2; //��

    public float StartTime = 1; //����
    public float SpawnTime = 10; //���� ������ �ð�

    [Header("�ܰ躰 ����")]
    public GameObject[] monster;

    private void Awake()
    {
        
    }

    void Start()
    {
        Invoke("Monster1", SpawnTime);
        
        GameObject player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
 
    }
    
    void Monster1()
    {
        //x �� ����
        float x = Random.Range(ss, es);
        //x �� ������ y�� �ڱ� �ڽ� ��
        Vector2 r = new Vector2(x, transform.position.y);
        
        for(int i = 0; i < 2; i ++)
        {
            //���� ����
            Instantiate(monster[0],new Vector2(ss + i, transform.position.y), Quaternion.identity);
        }
    }
}
