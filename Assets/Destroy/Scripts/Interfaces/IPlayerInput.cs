using UnityEngine;

public interface IPlayerInput
{
    void InputKeys();

    Vector3 MoveDirection();

    Vector3 LookDirection();

    bool IsAttack();
}

