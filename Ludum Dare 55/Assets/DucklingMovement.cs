using UnityEngine;

public class DucklingMovement : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.SetRotation(Random.Range(0f, 360f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0;
        _rigidbody.SetRotation(_rigidbody.rotation + 1);
        _rigidbody.MovePosition(_rigidbody.position + new Vector2(transform.up.x, transform.up.y) * Time.fixedDeltaTime);
    }
}
