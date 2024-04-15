using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingSound : MonoBehaviour
{
    public AudioClip[] chirps;
    
    private AudioSource _audioSource;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayChirp()
    {
        if (_audioSource.isPlaying)
            return;
        
        _audioSource.PlayOneShot(chirps[Random.Range(0, chirps.Length)]);
    }
}
