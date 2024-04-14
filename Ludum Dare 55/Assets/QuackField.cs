using System;
using System.Linq;
using UnityEngine;

public class QuackField : MonoBehaviour
{
    private const int BUFFER = 128;
    private const int DEVICE = 0;
    private const int QUACK_SCALE = 10;
    private AudioClip _audioClip;
    private float[] _samples = new float[BUFFER];
    private float _maxVolume = 0.01f;
    
    void Awake()
    {
        #if !UNITY_WEBGL
        _audioClip = Microphone.Start(Microphone.devices[DEVICE], true, 10, 5000);
        #endif
    }

    void Update()
    {
        var scale = GetCurrentVolume() * QUACK_SCALE;

        if (scale < QUACK_SCALE / 8f)
            scale = 0;

        scale = Math.Max(scale, Mathf.Lerp(transform.localScale.x, 0, Time.deltaTime * 10f));
        
        transform.localScale = new Vector3(scale, scale, 1);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var duckling = other.GetComponent<DucklingMovement>();

        if (duckling == null)
            return;
        
        #if UNITY_WEBGL
        duckling.OnQuack(1);
        #else
        duckling.OnQuack(GetCurrentVolume());
        #endif
    }

    private float GetCurrentVolume()
    {
        #if UNITY_WEBGL
        return Input.GetKeyDown(KeyCode.Space) ? 1f : 0f;
        #else
        var position = Microphone.GetPosition(Microphone.devices[DEVICE]) - BUFFER;
        if (position < 0)
        {
            return 0;
        }
        _audioClip.GetData(_samples, position);
        var currentVolume = _samples.Max();
        _maxVolume = Math.Max(_maxVolume, currentVolume);
        return currentVolume / _maxVolume;
        #endif
    }
}
