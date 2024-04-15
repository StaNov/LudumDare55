using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public bool rightToLeft;
    public Sprite[] carSprites;
    public Sprite[] carPaintSprites;
    
    private int _spriteIndex;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private SpriteRenderer _rendererPaint;
    private Vector3 _initPosition;

    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _rendererPaint = GetComponentsInChildren<SpriteRenderer>()[1];
        _initPosition = transform.position;
    }
    
    IEnumerator Start()
    {
        while (true)
        {
            _spriteIndex = Random.Range(0, carSprites.Length);
            _renderer.sprite = carSprites[_spriteIndex];
            _rendererPaint.sprite = carPaintSprites[_spriteIndex];

            _rendererPaint.color = new Color(Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f), Random.Range(0.5f, 1.0f));
            transform.position = _initPosition;
            _rigidbody.velocity = Vector2.right * Random.Range(6, 9) * (rightToLeft ? -1 : 1);

            while (Mathf.Abs(transform.position.x) < 13)
                yield return null;
        }
    }
}
