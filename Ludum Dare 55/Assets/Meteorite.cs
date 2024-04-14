using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Meteorite : MonoBehaviour
{
    private float shadowEnlargingTime;
    private const float meteoriteDespawnTime = 0.2f;
    private SpriteRenderer _shadowRenderer;
    private SpriteRenderer _meteoriteRenderer;
    private CircleCollider2D _collider;

    private List<GameObject> currentlyColliding = new();
    
    IEnumerator Start()
    {
        _shadowRenderer = transform.Find("Shadow").GetComponent<SpriteRenderer>();
        _meteoriteRenderer = transform.Find("FlyingMeteorite").GetComponent<SpriteRenderer>();
        _collider = _shadowRenderer.GetComponent<CircleCollider2D>();
        shadowEnlargingTime = Random.Range(1.5f, 2.5f);
        var loopStartTime = 0f;
        var basePosition = _meteoriteRenderer.transform.localPosition;

        while (true)
        {
            SetShadowScale(0);
            loopStartTime = loopStartTime != 0 ? Time.time : Time.time - Random.Range(0, shadowEnlargingTime);
            _meteoriteRenderer.color = Color.white;
            SetMeteoriteRendererLocalPosition(basePosition.x + 20);
            _collider.isTrigger = true;

            while (Time.time - loopStartTime < shadowEnlargingTime)
            {
                var scale = (Time.time - loopStartTime) / shadowEnlargingTime;
                SetShadowScale(scale * scale);
                yield return null;
            }

            while (_meteoriteRenderer.transform.localPosition.x > basePosition.x + 0.5f)
            {
                SetMeteoriteRendererLocalPosition(_meteoriteRenderer.transform.localPosition.x - 0.5f);
                yield return null;
            }

            _meteoriteRenderer.transform.localPosition = basePosition;

            foreach (var colliding in new List<GameObject>(currentlyColliding))
            {
                var hit = colliding.GetComponent<DucklingHit>();

                if (hit != null)
                {
                    hit.OnHit();
                }
            }

            _collider.isTrigger = false;
            
            yield return new WaitForSeconds(1f);

            var meteoriteDespawnStartTime = Time.time;

            while (Time.time - meteoriteDespawnStartTime < meteoriteDespawnTime)
            {
                SetMeteoriteAlpha(1 - (Time.time - meteoriteDespawnStartTime) / meteoriteDespawnTime);
                yield return null;
            }
        }
    }

    private void SetMeteoriteAlpha(float alpha)
    {
        var rendererColor = _meteoriteRenderer.color;
        rendererColor.a = alpha;
        _meteoriteRenderer.color = rendererColor;
    }

    private void SetShadowScale(float scale)
    {
        var newScale = _shadowRenderer.transform.localScale;
        newScale.x = scale;
        newScale.y = scale;
        _shadowRenderer.transform.localScale = newScale;
    }

    private void SetMeteoriteRendererLocalPosition(float position)
    {
        var newPosition = _meteoriteRenderer.transform.localPosition;
        newPosition.x = position;
        newPosition.y = position;
        _meteoriteRenderer.transform.localPosition = newPosition;
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
