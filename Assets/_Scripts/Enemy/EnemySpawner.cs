using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int enemiesPerWave = 3;
    [SerializeField] private float timeBetweenWaves = 5f;
    public int CurrentWave => currentWave;
    public event Action<int> WaveChanged;
    
    private int enemiesAlive;
    private int currentWave;

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        while (true)
        {
            currentWave++; 
            WaveChanged?.Invoke(currentWave);
            Debug.Log($"Wave {currentWave} started!");

            SpawnWave();
            enemiesPerWave += 2;
            while (enemiesAlive > 0)
            {
                yield return null;
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    private void SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            float spawnRadius = 4f;

            Vector2 randomCircle = Random.insideUnitCircle * spawnRadius;

            Vector3 spawnPosition = spawnPoint.position + new Vector3(
                randomCircle.x,
                0f,
                randomCircle.y
            );

            GameObject enemyObject = Instantiate(enemyPrefab, spawnPosition, spawnPoint.rotation);
            Debug.Log($"Spawned enemy {i + 1}/{enemiesPerWave} at {spawnPosition}");
            EnemyHealth enemyHealth = enemyObject.GetComponent<EnemyHealth>();

            if(enemyHealth != null)
            {
                enemiesAlive++;
                enemyHealth.Died += OnEnemyDied;
            }
        }
    }

    private void OnEnemyDied(EnemyHealth enemyHealth)
    {
        enemiesAlive--;
        enemyHealth.Died -= OnEnemyDied;

        Debug.Log($"Enemies alive: {enemiesAlive}");
    }
}