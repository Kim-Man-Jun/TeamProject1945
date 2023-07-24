using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SelectPlayer : MonoBehaviour
{
    public GameObject main; //메인화면 이미지
    public GameObject s1; //1번 캐릭 이미지
    public GameObject s2; // 이하 동문
    public GameObject s3;
    public GameObject s4;

    public int SelectNum = 0; //캐릭 선택 번호 0 > 1번 따라서 3 > 4번
    public bool isMain = true; //메인이미지 활성화 되어있는지
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        if(isMain == true) { //한번만 실행되게하기위함
        if (Input.anyKeyDown) //아무키나 누르면
        {  

             main.SetActive(false);
             isMain = false;   
        }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) //아래키 누르면 내려감
        {
            SelectNum += 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) //위키 누르면 올라감
        {
            SelectNum -= 1;
        }
        if(SelectNum == 0)  //0이면 1번 캐릭실행
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

    void SceneChanger() //SelectNum에따른 씬전환 
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
