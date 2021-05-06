using UnityEngine;

public class ChasePointer : SingletonMonoBehaviour<ChasePointer>
{
    public enum DirectionType
    {
        Forward, Back, Right, Left, Up, Down,
    }

    public Vector3 GetChasePoint() => transform.position;

    public Vector3 GetChasePointDirection(DirectionType directionType)
    {
        switch (directionType)
        {
            case DirectionType.Forward:
                return transform.forward;
            case DirectionType.Back:
                return -transform.forward;
            case DirectionType.Right:
                return transform.right;
            case DirectionType.Left:
                return -transform.right;
            case DirectionType.Up:
                return transform.up;
            case DirectionType.Down:
                return -transform.up;
            default:
                return transform.forward;
        }
    }
}
