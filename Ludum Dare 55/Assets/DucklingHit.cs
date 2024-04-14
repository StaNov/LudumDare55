using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DucklingHit : MonoBehaviour
{
    private MusicPlayer _musicPlayer;
    public Sprite splashSprite;

    void Awake()
    {
        _musicPlayer = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.StartsWith("Car"))
            OnHit();
    }

    public void OnHit()
    {
        var ducklingMovement = GetComponent<DucklingMovement>();
        if (ducklingMovement != null)
            ducklingMovement.enabled = false;
        
        var quackField = GetComponentInChildren<QuackField>();
        if (quackField != null)
            quackField.enabled = false;
        
        var duckMovement = GetComponent<DuckMovement>();
        if (duckMovement != null)
        {
            duckMovement.enabled = false;
            _musicPlayer.PlayLoss();
        }

        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<SpriteRenderer>().sprite = splashSprite;
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
