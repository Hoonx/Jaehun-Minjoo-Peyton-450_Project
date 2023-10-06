using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject[] Zombie;
    private int wave = 1;
    private int enemiesNum;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        enemiesNum = wave * (enemiesNum + 5);

    }

    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;

        spawnTime = 0f;
        enemiesNum--;
        wave++;
    }
}
