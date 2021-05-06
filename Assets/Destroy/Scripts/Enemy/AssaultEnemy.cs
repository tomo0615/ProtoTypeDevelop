using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class AssaultEnemy : BaseEnemy
{
    private EnemyMover _enemyMover;
    private EnemyShooter _enemyShooter;

    [SerializeField]
    protected float moveSpeed = 3.0f;
    [SerializeField]
    private bool isShotable = false;

    private void Awake()
    {
        _enemyMover = new EnemyMover(GetComponent<Rigidbody>(), transform);

        if (isShotable == false)
        {
            return;
        }
        _enemyShooter = GetComponent<EnemyShooter>();
    }

    private void Start()
    {
        this.UpdateAsObservable()
            .Select(playerPos=>ChasePointer.Instance.GetChasePoint())
            .Subscribe(playerPos =>
            {
                _enemyMover.Move(playerPos, moveSpeed);
            });

        this.UpdateAsObservable()
            .Where(_ => isShotable)
            .Subscribe(_ =>
            {
                _enemyShooter.Shooting();
            });
    }
}
