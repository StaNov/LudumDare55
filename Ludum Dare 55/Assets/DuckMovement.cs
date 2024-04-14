using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var lastUpdatePosition = _rigidbody.position;
        
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0;
        
        Vector2 direction = Vector2.zero;
        
        if (Input.GetKey(KeyCode.W))
            direction += Vector2.up;
        
        if (Input.GetKey(KeyCode.S))
            direction += Vector2.down;
        
        if (Input.GetKey(KeyCode.A))
            direction += Vector2.left;
        
        if (Input.GetKey(KeyCode.D))
            direction += Vector2.right;
        
        var position = _rigidbody.position;
        position += Time.fixedDeltaTime * 2 * direction.normalized;
        _rigidbody.MovePosition(position);

        if (position != lastUpdatePosition)
        {
            var rotation = position - lastUpdatePosition;
            _rigidbody.SetRotation(Quaternion.LookRotation(Vector3.forward, rotation.normalized));
        }
    }
}
