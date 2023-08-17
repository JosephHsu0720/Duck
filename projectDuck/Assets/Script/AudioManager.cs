using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

public class AudioManager
{
    static private int BGM_AudioID = 0;
    static string BGM_Name = string.Empty;

    /// <summary>
    /// Playing BGM By AudioClip
    /// </summary>
    /// <param name="clip"></param>
    static public void PlayBGM_AudioClip(AudioClip clip)
    {
        if (BGM_Name == clip.name) return;

        if (clip == null)
        {
            Debug.LogError($"Missing AudioClip {clip.name}");
            return;
        }
        EazySoundManager.PlayMusic(clip, 1f, true, true);
        BGM_Name = clip.name;
    }

    /// <summary>
    /// Playing Sound Effect By AudioClip
    /// </summary>
    /// <param name="clip"></param>
    static public void PlaySE_AudioClip(AudioClip clip)
    {
        if (BGM_Name == clip.name) return;

        if (clip == null)
        {
            Debug.LogError($"Missing AudioClip {clip.name}");
            return;
        }
        EazySoundManager.PlayMusic(clip, 1f, true, false);
        BGM_Name = clip.name;
    }

    static public void PauseBGM()
    {
        Audio audio = EazySoundManager.GetAudio(BGM_AudioID);

        if (audio == null) return;

        audio.Pause();
    }

    static public void ResumeBGM()
    {
        Audio audio = EazySoundManager.GetAudio(BGM_AudioID);

        if (audio == null) return;

        audio.Resume();
    }

    static public void SetBGMVolume(float value)
    {
        EazySoundManager.GlobalMusicVolume = value;
    }

    static public void SetSEVolume(float value)
    {
        EazySoundManager.GlobalUISoundsVolume = value;
    }
}
