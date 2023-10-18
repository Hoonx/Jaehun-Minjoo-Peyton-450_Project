using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Zombie;
    public int wave = 1;
    private int enemiesNum;
    private float spawnTime;
    private bool isSpawn = false;
    public float timeBetweenEnemiesSpawn = 0.5f;
    public int enemiesLeft;


    public NewWave newWave;
    // Start is called before the first frame update
    void Start()
    {
        StartWave();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if we should spawn
        if (enemiesNum > 0)
        {
            if (Time.time >= spawnTime)
            {
                Spawn();
                enemiesNum--;
                spawnTime = Time.time + timeBetweenEnemiesSpawn;
            }
        }

        if (enemiesLeft == 0 && !isSpawn)
        //else
        {
            // Start a new wave when all enemies are spawned
            isSpawn = true;
            wave++;
            newWave.totalWave--;
            newWave.UpdateWaveDisplay();
            StartCoroutine("spawnerTimer");

        }
    }

    IEnumerator spawnerTimer()
    {
        yield return new WaitForSeconds(10f);

        StartWave();
    }

    private void Spawn()
    {
        // Check if the Zombie array is not empty
        if (Zombie.Length > 0)
        {
            GameObject spawnedZombies = Zombie[0];
            Instantiate(spawnedZombies, LevelManager.main.startPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("error");
        }
    }

    private int EnemiesForWave(int wave)
    {

        return wave * 5; 
    }

    public void    StartWave()
    {
        
        enemiesNum = EnemiesForWave(wave);
        //enemiesLeft = enemiesNum;

        spawnTime = Time.time + timeBetweenEnemiesSpawn; // Start spawning immediately
        //wave++;
    }


}
