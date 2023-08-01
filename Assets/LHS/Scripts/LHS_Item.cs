using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//좌우로 이동 아래로 같이 이동
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
