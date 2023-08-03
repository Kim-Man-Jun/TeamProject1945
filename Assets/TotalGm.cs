using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalGm : MonoBehaviour
{
    public static TotalGm instance = null;

    public bool isClear1 = false;
    public bool isClear2 = false;
    public bool isClear3 = false;
    public bool isClear4 = false;
    public bool isMain = true; //메인이미지 활성화 되어있는지
    public string playingPlayer;


    void Awake()
    {
     
        if (instance == null)
            instance = this;

        // 인스턴스가 이미 있는 경우 오브젝트 제거
        else if (instance != this)
            Destroy(gameObject);

        // 이렇게 하면 다음 scene으로 넘어가도 오브젝트가 사라지지 않습니다.
        DontDestroyOnLoad(gameObject);
    }


}
