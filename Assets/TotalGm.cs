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
    public bool isMain = true; //�����̹��� Ȱ��ȭ �Ǿ��ִ���
    public string playingPlayer;


    void Awake()
    {
     
        if (instance == null)
            instance = this;

        // �ν��Ͻ��� �̹� �ִ� ��� ������Ʈ ����
        else if (instance != this)
            Destroy(gameObject);

        // �̷��� �ϸ� ���� scene���� �Ѿ�� ������Ʈ�� ������� �ʽ��ϴ�.
        DontDestroyOnLoad(gameObject);
    }


}
