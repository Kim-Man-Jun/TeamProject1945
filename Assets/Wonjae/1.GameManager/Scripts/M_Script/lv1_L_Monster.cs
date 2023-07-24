using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv1_L_Monster : MonoBehaviour
{
    public Transform ms;
    public GameObject Mbullet;
    public GameObject Item;

    public float Delay = 1f;
    public float moveSpeed = 2f;
    public Vector3 moveDirection = new Vector3(-1, -1, 0);
    void Start()
    {
        Invoke("CreateBullet", Delay);
    }

    void CreateBullet()
    {
        Instantiate(Mbullet, ms.position, Quaternion.identity);
        Invoke("CreateBullet", Delay);
    }
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
