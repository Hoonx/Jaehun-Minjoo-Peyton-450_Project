using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_EnemySpawner : MonoBehaviour
{
    public int firstWave = 8;
    public float enemiesPerSecond = 2f;
    public GameObject[] enemyPrefabs;
    public float timeBetweenWaves = 5f;
    public float difficultyFactor = 0.5f;

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Start() {
        StartWave();
    }
    private void Update() {
        if (!isSpawning) {
            return;
        }
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0) {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
    }
    private void StartWave() {
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void SpawnEnemy() {
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }
    private int EnemiesPerWave() {
        return Mathf.RoundToInt(firstWave * Mathf.Pow(currentWave, difficultyFactor));
    }
}
