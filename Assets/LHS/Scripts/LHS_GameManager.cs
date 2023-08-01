using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LHS_GameManager : MonoBehaviour
{
    public static LHS_GameManager instance;

    public int level = 1;
    public int itemNum;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if(itemNum == 3)
        {
            level = 2;
        }
    }
}
