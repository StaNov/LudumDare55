using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingCarHit : MonoBehaviour
{
    public Sprite splashSprite;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.name.StartsWith("Car"))
            return;

        GetComponent<DucklingMovement>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<SpriteRenderer>().sprite = splashSprite;
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
