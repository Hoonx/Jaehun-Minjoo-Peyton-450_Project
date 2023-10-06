using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Zombie;
    private int wave = 1;
    private int enemiesNum;
    private float spawnTime;
    private bool isSpawn = false;
    private float timeBetweenEnemiesSpawn = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        startWave();

    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        //spawnTime = 0f;

        while (isSpawn == true && enemiesNum>0)
        {
            if (spawnTime >= 1f/ timeBetweenEnemiesSpawn)
            {
                Spawn();
                enemiesNum--;
                spawnTime = 0f;
            }
        }
        isSpawn = false;
        wave++;
    }

    private void Spawn()
    {
        GameObject spawnedZombies = Zombie[0];
        Instantiate(spawnedZombies, LevelManager.main.startPoint.position, Quaternion.identity);
        
    }

    private int enemiesForWave(int wave)
    {
        return wave * 5; // Adjust this formula as needed for your game
    }

    private void startWave()
    {
        isSpawn = true;
        enemiesNum = enemiesForWave(wave);
    }


}
