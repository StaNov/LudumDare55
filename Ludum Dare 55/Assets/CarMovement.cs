using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public bool rightToLeft;
    
    private Rigidbody2D _rigidbody;
    private Vector3 _initPosition;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _initPosition = transform.position;
    }
    
    IEnumerator Start()
    {
        while (true)
        {
            transform.position = _initPosition;
            _rigidbody.velocity = Vector2.right * Random.Range(5, 7) * (rightToLeft ? -1 : 1);

            while (Mathf.Abs(transform.position.x) < 13)
                yield return null;
        }
    }
}
