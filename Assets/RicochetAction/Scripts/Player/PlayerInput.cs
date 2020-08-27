using UnityEngine;

namespace RicochetAction.Scripts.Player
{
    public class PlayerInput
    {
        private const KeyCode 
            ShotKey = KeyCode.JoystickButton5; //ZRButton

        private float _horizontal;

        private float _vertical;
        
        public void InputKeys()
        {
            _horizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
        }

        public Vector3 MoveDirection() =>
            (new Vector3(_horizontal, 0f, _vertical).normalized);

        public bool IsShot() => Input.GetKeyUp(ShotKey);
    }
}
