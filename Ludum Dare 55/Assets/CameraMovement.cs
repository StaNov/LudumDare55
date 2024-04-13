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
        var targetY = Mathf.Clamp(_dadDuck.position.y + 2, minHeight, maxHeight);
        var y = Mathf.Lerp(transform.position.y, targetY, 0.1f);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
