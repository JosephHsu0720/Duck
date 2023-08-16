using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class AudioManager
{
    static public void PlayBGM(AudioClip targetAC)
    {
        Debug.Log($"Now playing: {targetAC.name}");
        EazySoundManager.PlayMusic(targetAC, 1f, true, true);
    }

    static public void PlaySE(string name)
    {

    }
}
