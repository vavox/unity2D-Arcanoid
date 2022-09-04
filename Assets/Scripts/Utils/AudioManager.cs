using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

    public static bool Initialized
    {
        get { return initialized; }
    }

    // Initializes the audio manager
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.BallHit, Resources.Load<AudioClip>("Sound/BallHit"));
        audioClips.Add(AudioClipName.PaddleHit, Resources.Load<AudioClip>("Sound/PaddleHit"));
        audioClips.Add(AudioClipName.MenuButtonClick, Resources.Load<AudioClip>("Sound/MenuButtonClick"));
    }

    // Plays the audio clip with the given name
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
