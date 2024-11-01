using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Rigidbody2D rigid = null;

    public float ItemVelocity = 30f;

    private AudioSource Audio;

    public AudioClip HpUp;
    public AudioClip PowerUp;
    public AudioClip Bomb;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioSource>();

        int rnd = Random.Range(1, 5);

        //아이템 드롭 시 랜덤한 방향으로 나가게 만듦
        if (rnd == 1)
        {
            rigid.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
        }
        else if (rnd == 2)
        {
            rigid.AddForce(new Vector3(-ItemVelocity, ItemVelocity, 0f));
        }
        else if (rnd == 3)
        {
            rigid.AddForce(new Vector3(ItemVelocity, -ItemVelocity, 0f));
        }
        else if (rnd == 4)
        {
            rigid.AddForce(new Vector3(-ItemVelocity, -ItemVelocity, 0f));
        }

        Destroy(gameObject, 5f);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "PowerUp")
            {
                PlayerController.WeaponPower++;

                if (PlayerController.WeaponPower >= 3)
                {
                    PlayerController.WeaponPower = 3;
                }

                Debug.Log(PlayerController.WeaponPower);
                Audio.PlayOneShot(PowerUp);
                Destroy(gameObject);
            }

            else if (gameObject.tag == "Bomb")
            {
                PlayerController.Bomb++;

                if(PlayerController.Bomb >= 5)
                {
                    PlayerController.Bomb = 5;
                }

                Debug.Log(PlayerController.Bomb);
                Audio.PlayOneShot(Bomb);
                Destroy(gameObject);
            }

            else if (gameObject.tag == "HpUp")
            {
                PlayerController.NowHP += 30;

                if (PlayerController.NowHP >= 100)
                {
                    PlayerController.NowHP = 100;
                }
                Audio.PlayOneShot(HpUp);
                Destroy(gameObject);
            }
        }
    }
}
