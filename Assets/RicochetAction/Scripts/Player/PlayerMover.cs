using UnityEngine;

namespace RicochetAction.Scripts.Player
{
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
            _rigidbody.velocity = moveDirection;
            
            LookMoveDirection(moveDirection);
        }

        private void LookMoveDirection(Vector3 moveDirection)
        {
            if(moveDirection == Vector3.zero) return;
            
            var rotation = Quaternion.LookRotation(moveDirection);
            _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, 0.5f);
        }

    }
}
