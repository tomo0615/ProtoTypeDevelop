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
    }
    
    public void OnActiveAttackCollider(bool isActive)
    {
        _attackCollider.enabled = isActive;
    }
}
