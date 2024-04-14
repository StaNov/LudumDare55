using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip win;
    public AudioClip loss;
    
    private AudioSource _audioSource;
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayWin()
    {
        _audioSource.clip = win;
        _audioSource.loop = false;
        _audioSource.Stop();
        _audioSource.Play();
    }

    public void PlayLoss()
    {
        _audioSource.clip = loss;
        _audioSource.loop = false;
        _audioSource.Stop();
        _audioSource.Play();
    }
}
