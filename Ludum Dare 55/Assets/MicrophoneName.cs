using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicrophoneName : MonoBehaviour
{
    void Start()
    {
        var text = GetComponent<Text>();
        text.text = text.text.Replace("XXX", Microphone.devices[0]);
    }
}
