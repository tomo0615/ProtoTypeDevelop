using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField]
    private GameObject cationMark = null;

    private List<BaseEnemy> enemyList = new List<BaseEnemy>();

    public void InitializeWave()
    {
        //子のEnemyをListに格納
        enemyList = GetComponentsInChildren<BaseEnemy>().ToList();
    }

    public bool IsKillAllEnemy()
    {
        return GetActiveEnemyValue() == 0;
    }

    private int GetActiveEnemyValue()
    {
        return enemyList.Count(enemy => enemy.gameObject.activeSelf);
    }

    public void InstanceCationMark()
    {
        foreach (BaseEnemy enemy in enemyList)
        {
            Vector3 enemyPosition = enemy.gameObject.transform.position;

            Instantiate(cationMark, enemyPosition, Quaternion.identity);
        }
    }

    public void InstanceTransferEffect()
    {
        foreach(BaseEnemy enemy in enemyList)
        {
            Vector3 enemyPosition = enemy.gameObject.transform.position;

            //出現Effect
            // GameEffectManager.Instance
            //     .OnGenelateEffect(enemyPosition, EffectType.EF_Transfer);
        }
    }
}
