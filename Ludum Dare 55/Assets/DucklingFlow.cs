using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingFlow : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnDucklingFlow()
    {
        GetComponent<DucklingMovement>().enabled = false;
        var position = transform.position;
        position.z = 30;
        transform.position = position;
        GetComponent<CircleCollider2D>().enabled = false;
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector2.left * Random.Range(3, 8);
        _rigidbody.freezeRotation = false;
        _rigidbody.angularVelocity = Random.Range(120, 180);
    }
}
