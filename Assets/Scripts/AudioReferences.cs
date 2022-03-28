using UnityEngine;

public class AudioReferences : MonoBehaviour
{

    private static AudioReferences _i;
    public static AudioReferences AudioRef{
        get
        {
            if (_i == null)
                _i = FindObjectOfType(typeof(AudioReferences)) as AudioReferences;

            return _i;
        }
        set
        {
            _i = value;
        }
    }

    public SoundAudioClip[] soundAudioClipArray;

[System.Serializable]
    public class SoundAudioClip
    {
    public SoundManager.Sound sound;
    public AudioClip audioclip;

    }
}
