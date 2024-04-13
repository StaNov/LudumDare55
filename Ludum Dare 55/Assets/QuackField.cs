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
        var position = Microphone.GetPosition(Microphone.devices[DEVICE]) - BUFFER;
        if (position < 0)
        {
            return;
        }
        _audioClip.GetData(_samples, position);
        var currentVolume = _samples.Max();
        _maxVolume = Math.Max(_maxVolume, currentVolume);
        var realVolume = currentVolume / _maxVolume;
        var scale = realVolume * 10;
        transform.localScale = new Vector3(scale, scale, 1);
    }
}
