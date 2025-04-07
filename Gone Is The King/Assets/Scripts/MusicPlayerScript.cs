using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;       // Keep looping the music
        audioSource.playOnAwake = false;
        audioSource.Play();
    }
}
