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
        var position = _rigidbody.position;
        
        if (Input.GetKey(KeyCode.W))
        {
            position += Vector2.up * Time.fixedDeltaTime;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            position += Vector2.down * Time.fixedDeltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            position += Vector2.left * Time.fixedDeltaTime;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            position += Vector2.right * Time.fixedDeltaTime;
        }
        _rigidbody.MovePosition(position);
    }
}
