using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public int ActualEnemyCount { get; private set; }
    [SerializeField] private bool _finishedWave = false;
    [SerializeField] private GameObject[] _enemys;
    [SerializeField] private Transform[] _spawnPoints;
    private int _actualWave;
    // Start is called before the first frame update
    void Start()
    {
        _actualWave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (ActualEnemyCount == 0)
        {
            _finishedWave = true;
        }
    }
    public void NewWave()
    {
        if (_actualWave%5 == 0)
        {

        }
    }
    private bool WaveVerify()
    {
        return _finishedWave;
    }
    IEnumerator Spawn()
    {
        yield return new WaitUntil(WaveVerify);
    }
}
