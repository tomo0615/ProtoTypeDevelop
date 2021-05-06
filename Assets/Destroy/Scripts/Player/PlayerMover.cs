using UnityEngine;

public class PlayerMover
{
    private readonly Rigidbody _rigidbody;

    private readonly Transform _transform;

    public PlayerMover(Rigidbody rigidbody, Transform transform)
    {
        _rigidbody = rigidbody;
        _transform = transform;
    }

    public void Move(Vector3 moveDirection)
    {
        _rigidbody.MovePosition(_transform.position + moveDirection * Time.deltaTime);
    }
}
