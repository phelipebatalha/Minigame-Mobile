using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private  GameObject[] enemyPrefabs,_spawners;
    public bool canSpawn = false;
    public static EnemySpawner EnemySpawnerInstance;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float countdown = 2f;
    [SerializeField] private int waveNumber = 10;
    [SerializeField] private int waves = 0;
    public int _verify = 0;
    void Awake()
    {
        if(EnemySpawnerInstance == null)
        EnemySpawnerInstance = this;
        else{
            Destroy(gameObject);
        }
    }
    public void Spawning()
    {
        canSpawn = true;
        StartCoroutine(Spawner());

    }

    //void Touch(){
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        if(touch.phase == TouchPhase.Began){
    //            canSpawn = true;
    //        }
    //        if(touch.phase == TouchPhase.Ended){
    //            canSpawn = false;
    //        }
    //    }
    //}
    private IEnumerator Spawner () 
    {
        

        if (waves % 5 == 0 && waves > 0)
        {
            StartCoroutine(SpawnStrongWave());
        }
        else
        {
            StartCoroutine(SpawnWave());
        }

        countdown = timeBetweenWaves;
        waves++;
        yield return StartCoroutine(ShowCountdown()); // Mostra a contagem regressiva antes de iniciar a onda
        canSpawn = false;
    }

     private IEnumerator ShowCountdown()
    {
        
        yield return new WaitForSeconds(10f);

    }

    private IEnumerator SpawnWave(){

        for (int i = 0; i < waveNumber; i++)
        {
            int rand = Random.Range(0, enemyPrefabs.Length-1);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, _spawners[rand].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
        waveNumber++;
        Debug.Log("Iniciando nova Wave!");
    }

    private IEnumerator SpawnStrongWave()
    {
        GameObject enemyToSpawn = enemyPrefabs[2];

        Instantiate(enemyToSpawn, _spawners[0].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);

        waveNumber++;
        Debug.Log("Iniciando nova Wave Forte!");
    }
}

