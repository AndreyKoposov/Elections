using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    private static Dictionary<AudioSource, float> audios;

    private void Awake()
    {
        audios = new Dictionary<AudioSource, float>();

        AudioSource[] audiosArr = GetComponentsInChildren<AudioSource>();

        for (int i = 0; i < audiosArr.Length; i++)
        {
            audios.Add(audiosArr[i], audiosArr[i].volume);
        }
    }

    public static void SwitchSounds(bool isSound)
    {
        if (isSound)
            SoundsController.SoundOn();
        else
            SoundsController.SoundOff();
    }

    private static void SoundOn()
    {
        foreach(AudioSource audio in audios.Keys)
        {
            audio.volume = audios[audio];
        }
    }

    private static void SoundOff()
    {
        foreach (AudioSource audio in audios.Keys)
        {
            audio.volume = 0;
        }
    }
}
