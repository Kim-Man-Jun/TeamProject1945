using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectPlayer : MonoBehaviour
{
    public GameObject main; //����ȭ�� �̹���
    public GameObject s1; //1�� ĳ�� �̹���
    public GameObject s2; // ���� ����
    public GameObject s3;
    public GameObject s4;

    public int SelectNum = 0; //ĳ�� ���� ��ȣ 0 > 1�� ���� 3 > 4��
    public bool isMain = true; //�����̹��� Ȱ��ȭ �Ǿ��ִ���
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        if(isMain == true) { //�ѹ��� ����ǰ��ϱ�����
        if (Input.anyKeyDown) //�ƹ�Ű�� ������
        {  

             main.SetActive(false);
             isMain = false;   
        }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) //�Ʒ�Ű ������ ������
        {
            SelectNum += 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) //��Ű ������ �ö�
        {
            SelectNum -= 1;
        }
        if(SelectNum == 0)  //0�̸� 1�� ĳ������
        {
            if (isMain == false)  //
            { 
                s1p(); 
            
            }
            
        }
        if (SelectNum == 1)
        {
            s2p();
        }
        if (SelectNum == 2)
        {
            s3p();
        }
        if (SelectNum == 3)
        {
            s4p();
        }
        if(isMain == false) { 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneChanger();
        }
        }
        Init();
    }
    void Init()
    {
        if (SelectNum > 3)
        {
            SelectNum = 0;
        }
        if (SelectNum < 0)
        {
            SelectNum = 3;
        }
    }
    void s1p()
    {
        s1.SetActive(true);
        s4.SetActive(false);
        s2.SetActive(false); 
    }
    void s2p()
    {
        s2.SetActive(true);
        s3.SetActive(false);
        s1.SetActive(false);
    }
    void s3p()
    {
        s3.SetActive(true);
        s4.SetActive(false);
        s2.SetActive(false);
    }
    void s4p()
    {
        s4.SetActive(true);
        s1.SetActive(false);
        s3.SetActive(false);
    }

    void SceneChanger() //SelectNum������ ����ȯ 
    {



        if (SelectNum == 0)
        {
            SceneManager.LoadScene("Wonjae");
        }
        if (SelectNum == 1)
        {
            SceneManager.LoadScene("KMJ_Stage");
        }


        if (SelectNum == 2)
        {
            SceneManager.LoadScene("LHS_Scene");
        }
        if (SelectNum == 3)
        {
            SceneManager.LoadScene("102_Scene");
        }
    }
}
