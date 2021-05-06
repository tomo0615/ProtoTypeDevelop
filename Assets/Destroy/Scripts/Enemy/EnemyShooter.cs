using UnityEngine;
using Zenject;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyBullet = null;

    [SerializeField]
    private float shotInterval = 0.5f;

    private float elapsedTimeValue = 0;
    
    private void Start()
    {
        ShotBullet();
    }

    public void Shooting()
    {
        elapsedTimeValue += Time.deltaTime;

        if (elapsedTimeValue >= shotInterval)
        {
            ShotBullet();

            elapsedTimeValue = 0.0f;
        }
    }

    private void ShotBullet()
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
    }
}
