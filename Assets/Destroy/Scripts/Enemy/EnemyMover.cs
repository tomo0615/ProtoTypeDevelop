using UnityEngine;

public class EnemyMover  
{
    private readonly Rigidbody _rigidbody;
    private readonly Transform _transform;

    public EnemyMover(Rigidbody rigidbody, Transform transform)
    {
        _rigidbody = rigidbody;
        _transform = transform;
    }
    public void Move(Vector3 moveDirection, float moveSpeed)//Playerのいる方向に向いて進ませる
    {
        _transform.LookAt(moveDirection);
        _rigidbody.velocity = _transform.forward * moveSpeed;        
    }
}
