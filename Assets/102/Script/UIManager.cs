using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject OverPanel;
    public Text ammotext;
    public Text lifetext;
    public float overtime;
    void Start()
    {
        Screen.SetResolution(700, 1920, true);

    }

    private void Awake()
    {
         
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            lifetext.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player4Controller>().CurHp.ToString();
            ammotext.text = GameObject.FindGameObjectWithTag("Player").GetComponent<Player4Controller>().Hac.ToString();

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player4Controller>().CurHp <= 0)
            {
                OverPanel.SetActive(true);
             
            
            }
        }
    }
    
}
