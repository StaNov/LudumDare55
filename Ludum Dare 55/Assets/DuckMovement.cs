using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
        position += Time.fixedDeltaTime * 2 * direction;
        _rigidbody.MovePosition(position);
    }
}
