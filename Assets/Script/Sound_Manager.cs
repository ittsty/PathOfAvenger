using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource Walk;
    public AudioSource SFX;

    public AudioClip Boss_BGM;
    public AudioClip Normal_BGM;

    public AudioClip walk;
    public AudioClip Bow;
    public AudioClip Sword;
    public AudioClip Die;
    public AudioClip Item;
    public AudioClip BossFB;
    public AudioClip PlayerFB;
    public AudioClip Plate;

    public static Sound_Manager instance;


    void Start()
    {
        instance = this;
    }
    public void playwalk()
    {
        if (Walk.isPlaying == false)
        {
            Walk.pitch = UnityEngine.Random.Range(0.75f, 0.8f);
            Walk.clip = walk;
            Walk.Play();
        }
    }
    public void stopwalk()
    {
        Walk.Stop();
    }
    public void playBow() { playsound(Bow); }
    public void playSword() { playsound(Sword); }
    public void playDie() { playsound(Die); }
    public void playItem() { playsound(Item); }
    public void playBossFB() { playsound(BossFB); }
    public void playPlayerFB() { playsound(PlayerFB); }
    public void playPlate() { playsound(Plate); }

    public void playsound(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }

    public void ChangeBGM_boss()
    {
        BGM.Stop();
        BGM.clip = Boss_BGM;
        BGM.Play();
    }
    public void ChangeBGM_normal()
    {
        BGM.Stop();
        BGM.clip = Normal_BGM;
        BGM.Play();
    }
}
