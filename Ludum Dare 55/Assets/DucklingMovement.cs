using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DucklingMovement : MonoBehaviour
{
    private float _MinSpeed = 0.5f;
    private float _MaxSpeed = 2f;
    private Rigidbody2D _rigidbody;
    private GameObject _dadDuck;
    private float _speedMultiplier = 1;
    private float _angularSpeed;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.SetRotation(Random.Range(0f, 360f));
        _dadDuck = GameObject.Find("Duck");
        _angularSpeed = Random.Range(-1f, 1f);
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0;
        _rigidbody.SetRotation(_rigidbody.rotation + _angularSpeed);
        _rigidbody.MovePosition(_rigidbody.position + Time.fixedDeltaTime * _speedMultiplier * new Vector2(transform.up.x, transform.up.y));

        _speedMultiplier = Mathf.Lerp(_speedMultiplier, _MinSpeed, 0.02f);
    }

    public void OnQuack(float intensity)
    {
        var rotation = _dadDuck.transform.position - _rigidbody.transform.position;
        _rigidbody.SetRotation(Quaternion.LookRotation (Vector3.forward, rotation.normalized));
        _speedMultiplier = Math.Max(_speedMultiplier, (_MaxSpeed - _MinSpeed) * intensity + _MinSpeed);
    }
}