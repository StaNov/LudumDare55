using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerMovement : MonoBehaviour
{
    private Transform _duck;
    
    void Awake()
    {
        _duck = GameObject.Find("Duck").transform;
    }

    void Update()
    {
        transform.position = _duck.position;
    }
}
