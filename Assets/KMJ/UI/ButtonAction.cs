using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    AudioSource GameOver;
    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;



    private void Awake()
    {
        image1.enabled = false;
        image2.enabled = false;
        image3.enabled = false;
        image4.enabled = false;
    }
    void Start()
    {
        GameOver = GetComponent<AudioSource>();
        GameOver.Play();

      
       
    }
    
    void Update()
    {
        if (TotalGm.instance.playingPlayer == "player1")
        {
            image1.enabled = true;
        }
        if (TotalGm.instance.playingPlayer == "player2")
        {
            image2.enabled = true;
        }
        if (TotalGm.instance.playingPlayer == "player3")
        {
            image3.enabled = true;
        }
        if (TotalGm.instance.playingPlayer == "player4")
        {
            image4.enabled = true;
        }
    }

    public void Restart()
    {
       
        if (TotalGm.instance.playingPlayer == "player1")
        {
            SceneManager.LoadScene("Wonjae");
        }
        if (TotalGm.instance.playingPlayer == "player2")
        {
            PlayerController.Bomb = 2;
            PlayerController.WeaponPower = 0;
            PlayerController.NowHP = 100;
            BossController.BossAppear = 0;
            BossController.BossNowHp = 20000;
            BossController.BossClear = false;

            SceneManager.LoadScene("KMJ_Stage");

        }
        if (TotalGm.instance.playingPlayer == "player3")
        {
            SceneManager.LoadScene("LHS_Scene");
        }
        if (TotalGm.instance.playingPlayer == "player4")
        {
            SceneManager.LoadScene("102_Scene");
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
