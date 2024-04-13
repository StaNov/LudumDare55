using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float minHeight = int.MinValue;
    public float maxHeight = int.MaxValue;
    
    private Transform _dadDuck;
    void Awake()
    {
        _dadDuck = GameObject.Find("Duck").transform;
    }

    void FixedUpdate()
    {
        var targetY = Mathf.Clamp(_dadDuck.position.y, minHeight, maxHeight);
        var y = Mathf.Lerp(transform.position.y, targetY, 0.005f);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
