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
        while (true)
        {
            if (Time.time - lastChangeOfSprite > 0.1)
            {
                currentSprite = (currentSprite + 1) % sprites.Length;
                _renderer.sprite = sprites[currentSprite];
                lastChangeOfSprite = Time.time;
            }

            yield return null;
        }
    }
}
