using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour
{
    public Sprite meteoriteSprite;
    private Sprite emptySprite;
    private float shadowEnlargingTime;
    private const float meteoriteDespawnTime = 1f;
    private SpriteRenderer _renderer;
    IEnumerator Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        emptySprite = _renderer.sprite;
        shadowEnlargingTime = Random.Range(2f, 4f);
        var originalSpriteColor = _renderer.color;

        while (true)
        {
            SetScale(0);
            var loopStartTime = Time.time;
            _renderer.sprite = emptySprite;
            _renderer.color = originalSpriteColor;
            

            while (Time.time - loopStartTime < shadowEnlargingTime)
            {
                SetScale((Time.time - loopStartTime) / shadowEnlargingTime);
                yield return null;
            }

            _renderer.sprite = meteoriteSprite;
            _renderer.color = Color.white;
            yield return new WaitForSeconds(0.5f);

            var meteoriteDespawnStartTime = Time.time;

            while (Time.time - meteoriteDespawnStartTime < meteoriteDespawnTime)
            {
                SetAlpha((1 - (Time.time - meteoriteDespawnStartTime)) / meteoriteDespawnTime);
                yield return null;
            }
        }
    }

    private void SetAlpha(float alpha)
    {
        var rendererColor = _renderer.color;
        rendererColor.a = alpha;
        _renderer.color = rendererColor;
    }

    private void SetScale(float scale)
    {
        var newScale = transform.localScale;
        newScale.x = scale;
        newScale.y = scale;
        transform.localScale = newScale;
    }
}
