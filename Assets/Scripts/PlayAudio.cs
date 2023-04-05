using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    void PlayMusic()
    {
        audioSource.Play();
    }

    void StopMusic()
    {
        audioSource.Stop();
    }
}
