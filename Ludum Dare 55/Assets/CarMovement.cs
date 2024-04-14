using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public bool rightToLeft;
    public Sprite[] carSprites;
    
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private Vector3 _initPosition;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _initPosition = transform.position;
    }
    
    IEnumerator Start()
    {
        while (true)
        {
            _renderer.sprite = carSprites[Random.Range(0, carSprites.Length)];
            transform.position = _initPosition;
            _rigidbody.velocity = Vector2.right * Random.Range(6, 9) * (rightToLeft ? -1 : 1);

            while (Mathf.Abs(transform.position.x) < 13)
                yield return null;
        }
    }
}
