using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckAnimation : MonoBehaviour
{
    public Sprite[] sprites;
    
    private SpriteRenderer _renderer;
    
    IEnumerator Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        var lastChangeOfSprite = 0f;
        var currentSprite = 0;
        var lastPosition = transform.position;
        while (true)
        {
            if (Time.time - lastChangeOfSprite > 0.1 && lastPosition != transform.position)
            {
                currentSprite = (currentSprite + 1) % sprites.Length;
                _renderer.sprite = sprites[currentSprite];
                lastChangeOfSprite = Time.time;
            }

            lastPosition = transform.position;
            yield return null;
        }
    }
}
