using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicrophoneName : MonoBehaviour
{
    void Start()
    {
        var text = GetComponent<Text>();
        #if UNITY_WEBGL
        text.text = "This game is meant to be played with microphone which is not supported in WebGL.\nPlease consider downloading the native application instead for the full experience.\nIf you still want to play here, you can press Spacebar to quack and summon the ducklings.";
        #else
        text.text = text.text.Replace("XXX", Microphone.devices[0]);
        #endif
    }
}
