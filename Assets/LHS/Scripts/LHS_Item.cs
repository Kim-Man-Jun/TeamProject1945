using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//�¿�� �̵� �Ʒ��� ���� �̵�
public class LHS_Item : MonoBehaviour
{
    public float speed = 1f;

    void Start()
    {
            
    }

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
