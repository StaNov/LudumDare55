using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAnimation : MonoBehaviour
{
    public Sprite[] waterSprites;
    
    IEnumerator Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        for (var i = 0; ; i++)
        {
            spriteRenderer.sprite = waterSprites[i % waterSprites.Length];
            yield return new WaitForSeconds(0.1f);
        }
    }
}
