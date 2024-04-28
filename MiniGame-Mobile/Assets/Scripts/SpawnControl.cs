using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    public static SpawnControl Instance;
    public int ActualEnemyCount { get; private set; }
    [SerializeField] private bool _finishedWave = false;
    [SerializeField] private GameObject[] _enemys;
    [SerializeField] private Transform[] _spawnPoints;
    private int _actualWave;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _actualWave = 0;
        StartCoroutine(Spawn());
    }
    void Update()
    {
        if (ActualEnemyCount == 0)
        {
            _finishedWave = true;
        }
    }
    public void NewWave()
    {
        _actualWave++;
        for(int i = 0; i < (_actualWave * Mathf.Log10(5)+5); i++)
        {
            Instantiate(_enemys[Random.Range(0, _enemys.Length - 1)], _spawnPoints[Random.Range(0, _spawnPoints.Length)]);
        }
        if (_actualWave%5 == 0)
        {
            Instantiate(_enemys[_enemys.Length - 1]);
        }
    }
    private bool WaveVerify()
    {
        return _finishedWave;
    }
    public void AddEnemy()
    {
        ActualEnemyCount++;
    }
    public void RemoveEnemy()
    {
        ActualEnemyCount--;
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            NewWave();
            yield return new WaitUntil(WaveVerify);
            _finishedWave = false ;
        }
    }
}
