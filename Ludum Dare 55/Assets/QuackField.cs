using System.Linq;
using UnityEngine;

public class QuackField : MonoBehaviour
{
    private const int BUFFER = 128;
    private const int DEVICE = 0;
    private AudioClip _audioClip;
    private float[] _samples = new float[BUFFER];
    
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
        transform.localScale = new Vector3(_samples.Max() * 100, _samples.Max() * 100, 1);
    }
}
