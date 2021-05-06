using System;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected int hitPoint = 7;

    [SerializeField]
    protected Rigidbody _rigidbody;

    public void ApplyDamage(Vector3 impactDirection)
    {
        _rigidbody.velocity = impactDirection * 50.0f;
        //吹っ飛ばす挙動だけなのでコメントアウト中
        // hitPoint--;
        // if (hitPoint > 0) return;
        // gameObject.SetActive(false);
    }
}
