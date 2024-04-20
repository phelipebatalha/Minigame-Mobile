using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;
    [SerializeField] private  GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = false;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float countdown = 2f;
    [SerializeField] private int waveNumber = 10;
    [SerializeField] private int waves = 0;

    private void Update()
    {
        Touch();
        if (canSpawn)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
                //canSpawn = true;
                StartCoroutine(Spawner());
                canSpawn = false;
            //}
        }
    }
    void Touch(){
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                canSpawn = true;
            }
            if(touch.phase == TouchPhase.Ended){
                canSpawn = false;
            }
        }
    }
    private IEnumerator Spawner () 
    {
        yield return StartCoroutine(ShowCountdown()); // Mostra a contagem regressiva antes de iniciar a onda

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
        canSpawn = false;
    }

     private IEnumerator ShowCountdown()
    {
        
        yield return new WaitForSeconds(3f);

    }

    private IEnumerator SpawnWave(){
        for (int i = 0; i < waveNumber; i++)
        {
            int rand = Random.Range(0, enemyPrefabs.Length-1);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
        waveNumber++;
        Debug.Log("Iniciando nova Wave!");
    }

    private IEnumerator SpawnStrongWave()
    {
        GameObject enemyToSpawn = enemyPrefabs[3];

        Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnRate);

        waveNumber++;
        Debug.Log("Iniciando nova Wave Forte!");
    }
}

