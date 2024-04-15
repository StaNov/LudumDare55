using UnityEngine;

public class DucklingFlow : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private MusicPlayer _musicPlayer;
    private GameObject _gameOverPanel;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _musicPlayer = GameObject.Find("MusicPlayer").GetComponent<MusicPlayer>();
        _gameOverPanel = GameObject.Find("GUI").transform.GetChild(1).gameObject;
    }

    public void OnDucklingFlow()
    {
        var ducklingMovement = GetComponent<DucklingMovement>();
        if (ducklingMovement != null)
        {
            ducklingMovement.enabled = false;
        }
        var duckMovement = GetComponent<DuckMovement>();
        if (duckMovement != null)
        {
            _musicPlayer.PlayLoss();
            duckMovement.enabled = false;
            _gameOverPanel.SetActive(true);
        }

        var position = transform.position;
        position.z = 30;
        transform.position = position;
        GetComponent<CircleCollider2D>().enabled = false;
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector2.left * Random.Range(3, 8);
        _rigidbody.freezeRotation = false;
        _rigidbody.angularVelocity = Random.Range(180, 360) * (Random.Range(0, 2) == 0 ? 1 : -1);
    }
}
