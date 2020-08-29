using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace RicochetAction.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInput _playerInput;

        private PlayerMover _playerMover;

        private PlayerShooter _playerShooter;
        
        [SerializeField] private float moveSpeed = 10.0f;
        
        private void Awake()
        {
            _playerInput = new PlayerInput();

            _playerMover = new PlayerMover(GetComponent<Rigidbody>() , transform);

            _playerShooter = GetComponent<PlayerShooter>();
        }

        private void Start()
        {
            //InputDebug
            // this.UpdateAsObservable()
            //     .Where(_=> Input.anyKeyDown)
            //     .Subscribe(_ =>
            //     {
            //         foreach(KeyCode code in Enum.GetValues(typeof(KeyCode)))
            //         {
            //             if (Input.GetKeyDown(code))
            //             {
            //                 // 入力されたキー名を表示
            //                 Debug.Log(code.ToString());
            //             }
            //         }
            //     });
            
            //Input
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    _playerInput.InputKeys();
                });
            
            //Move
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    _playerMover.Move(_playerInput.MoveDirection() * moveSpeed);
                });
            
            //Shot
            this.UpdateAsObservable()
                .Where(_=> _playerInput.IsShot())
                .Subscribe(_ =>
                {
                    _playerShooter.ShotBullet();
                });
        }
    }
}
