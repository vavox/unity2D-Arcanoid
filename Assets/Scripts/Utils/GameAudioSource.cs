using UnityEngine;

// An audio source for the entire game
public class GameAudioSource : MonoBehaviour
{
    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        // initialize audio manager
        if (!AudioManager.Initialized)
        {
            // initialize audio manager and persist audio source across scenes
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Initialize(audioSource);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // duplicate game object, so destroy
            Destroy(gameObject);
        }
    }
}
