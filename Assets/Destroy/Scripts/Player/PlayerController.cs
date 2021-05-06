using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour, IDamageable
{
    #region インスタンス変数
    private IPlayerInput _playerInput;

    private PlayerMover _playerMover;
    
    private PlayerRotater _playerRotater;

    private PlayerRayCaster _playerRayCaster;

    private PlayerCatcher _playerCatcher;
    #endregion
    
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
        
        _playerCatcher = GetComponentInChildren<PlayerCatcher>();
    }

    private void Start()
    {
        //input keys
        this.UpdateAsObservable()
            .Subscribe(_=>
            {
                _playerInput.InputKeys();
            });
        
        //move
        this.UpdateAsObservable()
            .Where(_=>_playerInput.IsCatch() == false)
            .Subscribe(_ =>
            {
                _playerMover.Move(_playerInput.MoveDirection() * moveSpeed);
            });
        
        //rotate
        this.UpdateAsObservable()
            .Where(_=>_playerInput.IsCatch() == false)
            .Select(rayHitPosition=>_playerRayCaster.GetPositionByRay(_playerInput.LookDirection()))
            .Subscribe(rayHitPosition=>
            {
                _playerRotater.LookRotation(rayHitPosition);
            });

        //catch
        this.UpdateAsObservable()
            .Subscribe(isCatch =>
            {
                _playerCatcher.OnActiveCatchableArea(_playerInput.IsCatch());
            });
    }
    
    public void ApplyDamage()
    {
        Debug.Log("player:damage");
    }
}
