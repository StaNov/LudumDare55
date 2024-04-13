using UnityEngine;

public class DucklingMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private GameObject _dadDuck;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.SetRotation(Random.Range(0f, 360f));
        _dadDuck = GameObject.Find("Duck");
    }

    void FixedUpdate()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0;
        _rigidbody.SetRotation(_rigidbody.rotation + 1);
        _rigidbody.MovePosition(_rigidbody.position + new Vector2(transform.up.x, transform.up.y) * Time.fixedDeltaTime);
    }

    public void OnQuack()
    {
        var rotation = _dadDuck.transform.position - _rigidbody.transform.position;
        _rigidbody.SetRotation(Quaternion.LookRotation (Vector3.forward, rotation.normalized));
    }
}
