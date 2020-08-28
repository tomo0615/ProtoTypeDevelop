using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RicochetAction.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        //private PlayerInput _playerInput;

        private PlayerMover _playerMover;

        [SerializeField] private float moveSpeed = 10f;
        
        private void Awake()
        {
            //_playerInput = new PlayerInput();

            _playerMover = new PlayerMover(GetComponent<Rigidbody>() , transform);
        }

        private void Start()
        {
            //Debug
            this.UpdateAsObservable()
                //.Where(_=> Input.anyKeyDown)
                .Subscribe(_ =>
                {
                    foreach(KeyCode code in Enum.GetValues(typeof(KeyCode)))
                    {
                        if (Input.GetKeyDown(code))
                        {
                            // 入力されたキー名を表示
                            Debug.Log(code.ToString());
                        }
                    }
                });
            
            //Input
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    //_playerInput.InputKeys();
                });
            
            //Move
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    //_playerMover.Move(_playerInput.MoveDirection() * moveSpeed);
                    //Debug.Log(_playerInput.MoveDirection());
                });
            
            //Shot
            this.UpdateAsObservable()
                //.Where(_=> _playerInput.IsShot())
                .Subscribe(_ =>
                {
                    Debug.Log("Shot");
                });
        }
        
        public void Fire(InputAction.CallbackContext context)
        {
            Debug.Log("Fire!");
        }
    }
}
