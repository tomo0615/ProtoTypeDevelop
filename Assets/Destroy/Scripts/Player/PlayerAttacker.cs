using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    private Collider _attackCollider;

    private void Awake()
    {
        _attackCollider = GetComponent<Collider>();
    }

    private void Start()
    {
        _attackCollider.enabled = false;

        this.OnCollisionEnterAsObservable()
            .Select(collision =>collision.gameObject.GetComponent<IDamageable>())
            .Where(collision=> collision != null)
            .Subscribe(collision =>
            {
                collision.ApplyDamage(transform.forward);
            });
    }
    
    public void OnActiveAttackCollider(bool isActive)
    {
        _attackCollider.enabled = isActive;
    }
}
