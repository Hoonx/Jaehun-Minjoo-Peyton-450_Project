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

    // Start is called before the first frame update
    void Start()
    {
        enemiesNum = enemiesForWave(wave);

    }

    // Update is called once per frame
    void Update()
    {
        //spawnTime += Time.deltaTime;
        //spawnTime = 0f;
        
        if (isSpawn == true && enemiesNum>0)
        {
            Spawn();
            enemiesNum--;
            wave++;

        }
    }

    private void Spawn()
    {
        if (Zombie.Length > 0)
        {
            GameObject spawnedZombies = Zombie[0];
            Instantiate(spawnedZombies, LevelManager.main.startPoint.position, Quaternion.identity);
        }
    }

    private int enemiesForWave(int wave)
    {
        return wave * 5; // Adjust this formula as needed for your game
    }


}
