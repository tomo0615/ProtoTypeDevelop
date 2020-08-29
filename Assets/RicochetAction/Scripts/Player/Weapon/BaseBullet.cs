using UnityEngine;

namespace RicochetAction.Scripts.Player.Weapon
{
    public class BaseBullet : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10.0f;

        protected Rigidbody Rigidbody;
        
        public void InitializeBullet()
        {
            Rigidbody = GetComponent<Rigidbody>();
            
            Rigidbody.velocity = transform.forward * moveSpeed;
        }
    }
}
