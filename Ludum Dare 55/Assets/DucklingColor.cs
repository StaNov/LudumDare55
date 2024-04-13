using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingColor : MonoBehaviour
{
    private const float min = 230f/256;
    private const float max = 255f/256;
    
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        float color = Random.Range(min, max);
        spriteRenderer.color = new Color(1, color, color);
    }
}
