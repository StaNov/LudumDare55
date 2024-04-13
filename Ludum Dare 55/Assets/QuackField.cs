using System;
using System.Linq;
using UnityEngine;

public class QuackField : MonoBehaviour
{
    private const int BUFFER = 128;
    private const int DEVICE = 0;
    private AudioClip _audioClip;
    private float[] _samples = new float[BUFFER];
    private float _maxVolume;
    
    void Awake()
    {
        _audioClip = Microphone.Start(Microphone.devices[DEVICE], true, 10, 5000);
    }

    void Update()
    {
        var scale = GetCurrentVolume() * 10;
        transform.localScale = new Vector3(scale, scale, 1);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var duckling = other.GetComponent<DucklingMovement>();

        if (duckling == null)
            return;
        
        duckling.OnQuack(GetCurrentVolume());
    }

    private float GetCurrentVolume()
    {
        var position = Microphone.GetPosition(Microphone.devices[DEVICE]) - BUFFER;
        if (position < 0)
        {
            return 0;
        }
        _audioClip.GetData(_samples, position);
        var currentVolume = _samples.Max();
        _maxVolume = Math.Max(_maxVolume, currentVolume);
        return currentVolume / _maxVolume;
    }
}
