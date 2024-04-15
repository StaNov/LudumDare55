using UnityEngine;

public class DucklingHit : MonoBehaviour
{
    private MusicPlayer _musicPlayer;
    private GameObject _gameOverPanel;
    public Sprite splashSprite;

    void Awake()
    {
        _musicPlayer = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
        _gameOverPanel = GameObject.Find("GUI").transform.GetChild(1).gameObject;
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
        
        var duckMovement = GetComponent<DuckMovement>();
        if (duckMovement != null)
        {
            duckMovement.enabled = false;
            GameObject.Find("QuackField").SetActive(false);
            _musicPlayer.PlayLoss();
            _gameOverPanel.SetActive(true);
        }

        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<SpriteRenderer>().sprite = splashSprite;
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
