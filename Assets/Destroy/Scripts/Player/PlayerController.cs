using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    #region インスタンス変数
    private IPlayerInput _playerInput;

    private PlayerMover _playerMover;
    
    private PlayerRotater _playerRotater;

    private PlayerRayCaster _playerRayCaster;
    #endregion
    
    [SerializeField]
    private PlayerAttacker playerAttacker = null;
    
    [SerializeField]
    private float moveSpeed = 20.0f;

    private Camera _camera = null;

    private void Awake()
    {
        _camera = Camera.main;

        _playerInput = new PlayerPCInput();

        _playerMover = new PlayerMover(GetComponent<Rigidbody>(), transform);

        _playerRotater = new PlayerRotater(transform);

        _playerRayCaster = new PlayerRayCaster(_camera, transform);
    }

    private void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_=>
            {
                _playerInput.InputKeys();
            });
        
        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                _playerMover.Move(_playerInput.MoveDirection() * moveSpeed);
            });
        
        this.UpdateAsObservable()
            .Select(rayHitPosition=>_playerRayCaster.GetPositionByRay(_playerInput.LookDirection()))
            .Subscribe(rayHitPosition=>
            {
                _playerRotater.LookRotation(rayHitPosition);
            });
        
        //攻撃切り替え
        this.UpdateAsObservable()
            .Select(flag => _playerInput.IsAttack())
            .Subscribe(flag =>
            {
                playerAttacker.OnActiveAttackCollider(flag);
            });
    }
}
