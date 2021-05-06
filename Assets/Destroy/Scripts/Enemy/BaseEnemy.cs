using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected int hitPoint = 7;
    
    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        damageable?.ApplyDamage();
    }

    public void ApplyDamage()
    {
        hitPoint--;

        if (hitPoint > 0) return;
        
        //撃破時Effect
        // GameEffectManager.Instance
        //     .OnGenelateEffect(transform.position, EffectType.EF_Explosion_shape);

        gameObject.SetActive(false);
    }
}
