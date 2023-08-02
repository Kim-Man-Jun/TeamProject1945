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

        SceneManager.LoadScene("StartScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
