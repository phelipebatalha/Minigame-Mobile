using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private LeaderboardManager leadman;
    [SerializeField] private EnemySpawner spawner;
    private float timer;
    private void Awake()
    {
        timer = 0;
    }
    private void Update()
    {
        if (timer > 20)
        {
            GameEnder();
        }
        else
        {
            timer = Time.time;
        }
    }
    private void GameEnder()
    {
        leadman.AddNewEntry("Testador", spawner.waves);
        SceneManager.LoadScene(0);
    }
}
