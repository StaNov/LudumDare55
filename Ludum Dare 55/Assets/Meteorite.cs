using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Meteorite : MonoBehaviour
{
    public Sprite meteoriteSprite;
    private Sprite emptySprite;
    private float shadowEnlargingTime;
    private const float meteoriteDespawnTime = 0.2f;
    private SpriteRenderer _renderer;
    private CircleCollider2D _collider;

    private List<GameObject> currentlyColliding = new();
    
    IEnumerator Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();
        emptySprite = _renderer.sprite;
        shadowEnlargingTime = Random.Range(2f, 4f);
        var originalSpriteColor = _renderer.color;
        var loopStartTime = 0f;

        while (true)
        {
            SetScale(0);
            loopStartTime = loopStartTime != 0 ? Time.time : Time.time - Random.Range(0, shadowEnlargingTime);
            _renderer.sprite = emptySprite;
            _renderer.color = originalSpriteColor;
            _collider.isTrigger = true;

            while (Time.time - loopStartTime < shadowEnlargingTime)
            {
                var scale = (Time.time - loopStartTime) / shadowEnlargingTime;
                SetScale(scale * scale);
                yield return null;
            }

            _renderer.sprite = meteoriteSprite;
            _renderer.color = Color.white;

            foreach (var colliding in new List<GameObject>(currentlyColliding))
            {
                var hit = colliding.GetComponent<DucklingHit>();

                if (hit != null)
                {
                    hit.OnHit();
                }
            }

            _collider.isTrigger = false;
            
            yield return new WaitForSeconds(1.5f);

            var meteoriteDespawnStartTime = Time.time;

            while (Time.time - meteoriteDespawnStartTime < meteoriteDespawnTime)
            {
                SetAlpha(1 - (Time.time - meteoriteDespawnStartTime) / meteoriteDespawnTime);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentlyColliding.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        currentlyColliding.Remove(other.gameObject);
    }
}
