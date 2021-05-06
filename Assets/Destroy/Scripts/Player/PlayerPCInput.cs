using UnityEngine;

public class PlayerPCInput : IPlayerInput
{
    private const KeyCode
        ShotKey = KeyCode.Mouse0,
        CatchKey = KeyCode.Mouse1;

    private float _horizontal;

    private float _vertical;

    public void InputKeys()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
        _vertical = Input.GetAxisRaw("Vertical");
    }

    public Vector3 MoveDirection() =>
        (new Vector3(_horizontal, 0f, _vertical).normalized);

    public Vector3 LookDirection() =>
        (Input.mousePosition);

    public bool IsShot() => Input.GetKeyUp(ShotKey);

    public bool IsCatch() => Input.GetKey(CatchKey);
}
