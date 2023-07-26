using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WJ_Homing : MonoBehaviour
{
    public float BSpeed = 2.0f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * BSpeed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
