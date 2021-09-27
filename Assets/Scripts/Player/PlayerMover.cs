using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Vector3 _direction;
    private float _xDirection;
    private float _zDirection;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        _xDirection = Input.GetAxisRaw("Horizontal");
        _zDirection = Input.GetAxisRaw("Vertical");
        
        _direction = (forward * _zDirection + right * _xDirection) * _speed;
        _direction.y = _rigidbody.velocity.y;
        Move(_direction);
    }

    private void Move(Vector3 direction)
    {
        _rigidbody.velocity = direction;
    }

    
}
