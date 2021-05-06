using System;
using UnityEngine;

public class PlayerCatcher : MonoBehaviour
{
    private Collider _catchableArea;

    [SerializeField]
    private Transform leftOrigin = null;

    [SerializeField]
    private Transform rightOrigin = null;
    
    private void Awake()
    {
        _catchableArea = GetComponent<Collider>();
    }

    private void Start()
    {
        _catchableArea.enabled = false;
    }

    public void OnActiveCatchableArea(bool isActive)
    {
        _catchableArea.enabled = isActive;
    }

    public Vector3 GetOriginPosition(bool isLeft)
    {
        if (isLeft)
        {
             return leftOrigin.position;
        }
        else
        {
            return rightOrigin.position;
        }
    }
}
