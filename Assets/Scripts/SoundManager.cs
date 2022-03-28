using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{

    public enum Sound
    {
        CubeStack,
        WallHit,
        Die,
        LevelCompleted
    }

    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (AudioReferences.SoundAudioClip soundAudioClip in AudioReferences.AudioRef.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioclip;
            }
            
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
}
