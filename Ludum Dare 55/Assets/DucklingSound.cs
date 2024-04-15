using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DucklingSound : MonoBehaviour
{
    public AudioClip[] chirps;
    public AudioSource audioSource;
    
    public void PlayChirp()
    {
        if (audioSource.isPlaying)
            return;
        
        audioSource.PlayOneShot(chirps[Random.Range(0, chirps.Length)]);
    }
}
