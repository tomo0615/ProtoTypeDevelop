using UnityEngine;

public class PlayerRotater
{
    private readonly Transform _transform;

    public PlayerRotater(Transform transform)
    {
        _transform = transform;
    }

    public void LookRotation(Vector3 lookDirection)
    {
        _transform.LookAt(lookDirection);
    }
}
