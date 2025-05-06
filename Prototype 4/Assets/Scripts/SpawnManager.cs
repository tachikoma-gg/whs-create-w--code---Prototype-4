using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;
    [SerializeField] private float spawnRange;

    private List<GameObject> enemies = new();

    private int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    void Update()
    {
        if(enemies.Count == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Instantiate(powerupPrefab, randomSpawnPosition, powerupPrefab.transform.rotation);

        for(int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, randomSpawnPosition, enemyPrefab.transform.rotation);
            enemies.Add(enemy);
        }
    }

    Vector3 randomSpawnPosition
    {
        get
        {
            float x = Random.Range(-spawnRange, spawnRange);
            float y = 0;
            float z = Random.Range(-spawnRange, spawnRange);

            return new(x, y, z);
        }
    }

    public void DestroyEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
