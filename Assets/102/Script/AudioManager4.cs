using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager4 : MonoBehaviour
{
    public AudioClip soundExplosion; //����� �Ҹ��� ������ ����ϴ�.
    public AudioClip soundbomerang;
    public AudioClip soundGetItem;
    public AudioClip soundHeal;
    public AudioClip soundBg2;
    public GameObject Boss;
    AudioSource myAudio; //AudioSorce ������Ʈ�� ������ ����ϴ�.
    public static AudioManager4 instance;  //�ڱ��ڽ��� ������ ����ϴ�.
    void Awake() //Start���ٵ� ����, ��ü�� �����ɶ� ȣ��˴ϴ�
    {
        if (AudioManager4.instance == null) //incetance�� ����ִ��� �˻��մϴ�.
        {
            AudioManager4.instance = this; //�ڱ��ڽ��� ����ϴ�.
        }
    }
    void Start()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>(); //AudioSource ������Ʈ�� ������ ����ϴ�.
    }
    public void PlaySound()
    {
        myAudio.PlayOneShot(soundExplosion); //soundExplosion�� ����մϴ�.
    }
    public void PlayBomerang() 
    {
        myAudio.PlayOneShot(soundbomerang);
    }
    public void PlayGetItem() 
    {
        myAudio.PlayOneShot(soundGetItem);
    }
    public void PlayHeal() {
        myAudio.PlayOneShot(soundHeal);
    }
    public void PlayBg2() 
    {
        myAudio.PlayOneShot(soundBg2);
    }
   public void StopBg2() 
    {
        myAudio.Stop();
    }

    void Update()
    {
       
    }

}
