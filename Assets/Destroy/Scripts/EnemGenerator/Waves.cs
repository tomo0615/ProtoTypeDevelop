using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Linq;

public class Waves : MonoBehaviour
{
    [SerializeField]
    private float waveStartWaitTime = 3f;

    [SerializeField]
    private float waveIntervalTime = 1.5f;

    private List<Wave> waveList = new List<Wave>();

    private int currentWaveIndex = 0;

    private Wave CurrentWave => waveList[currentWaveIndex];
    private Wave LastWave => waveList[WaveMaxCount - 1];

    private int WaveMaxCount => waveList.Count;　//UIにWave最大数の表示があるかもしれないので残してる

    private bool HasNextWave => currentWaveIndex + 1 < WaveMaxCount;
    
    private void Awake()
    {
        InitializeWaveList();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(waveStartWaitTime);　//Fadeが終わるまでの時間待たせるため

        yield return StartCoroutine(SetActiveWave());

        //Wave更新用
        this.UpdateAsObservable()
            .Where(_ => CurrentWave.IsKillAllEnemy() && HasNextWave)
            .Subscribe(_ => OnUpdateNextWave());
    }

    private void InitializeWaveList()
    {
        waveList = GetComponentsInChildren<Wave>().Select(
            (wave, index) =>
            {
                wave.InitializeWave();
                wave.gameObject.SetActive(false);
                return wave;
            }).ToList();
    }

    private IEnumerator SetActiveWave()
    {
        CurrentWave.InstanceCationMark();

        yield return new WaitForSeconds(waveIntervalTime);

        CurrentWave.InstanceTransferEffect();
        
        CurrentWave.gameObject.SetActive(true);
    }

    private void OnUpdateNextWave()
    {
        //Waveの変更(ex.1->2)
        //ランダムに選択にさせる
        //CurrentWave.gameObject.SetActive(false);

        currentWaveIndex++;

        StartCoroutine(SetActiveWave());
    }
}
