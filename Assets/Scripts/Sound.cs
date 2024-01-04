using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    AudioSource sound;
    AudioClip audioMove;
    //AudioClip audioGreetings;
    AudioClip audioStart;
    AudioClip audioSolved;
    AudioClip audioSolved2;
    AudioClip audioGoodbye;

    void Start()
    {
        sound = GetComponent<AudioSource>();

        audioMove = Resources.Load<AudioClip>("move");
        //audioGreetings = Resources.Load<AudioClip>("papich_privetstvie");
        audioStart = Resources.Load<AudioClip>("start");
        audioSolved = Resources.Load<AudioClip>("vika_edit");
        //audioSolved = Resources.Load<AudioClip>("papich_umniy");
        //audioSolved2 = Resources.Load<AudioClip>("easyforpapizzi");
        audioSolved2 = Resources.Load<AudioClip>("success");
        //audioGoodbye = Resources.Load<AudioClip>("papich_edit_proshanie");
        audioGoodbye = Resources.Load<AudioClip>("byebye");
    }

    public void PlayMove()
    {
        sound.PlayOneShot(audioMove);
    }

    /*public void PlayGreetings()
    {
        sound.PlayOneShot(audioGreetings);
    }*/

    public void PlayStart()
    {
        sound.PlayOneShot(audioStart);
    }

    public void PlaySolved()
    {
        sound.PlayOneShot(audioSolved);
    }

    public void PlaySolved2()
    {
        sound.PlayOneShot(audioSolved2);
    }

    public void PlayGoodbye()
    {
        sound.PlayOneShot(audioGoodbye);
    }

}
