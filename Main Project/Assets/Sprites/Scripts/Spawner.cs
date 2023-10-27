using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] Zombie;
    public int wave = 0; // Initialize wave as 0
    private int enemiesNum; // total number of enemies that should spawn
    public float timeBetweenEnemiesSpawn = 0.5f;
    private float spawnTime;
    private float timeBetweenWaves = 20f;
    public bool isSpawn = false;
    public int enemiesLeft; //enemies left that are alive
    public GameObject restartButton;
    public Text restart;

    public static Spawner instance;

    public NewWave newWave;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartCoroutine(StartWaves());
    }

    void Update()
    {
        // Check if we should spawn
        if (enemiesNum > 0 && Time.time >= spawnTime)
        {
            Spawn();
            enemiesNum--;
            spawnTime = Time.time + timeBetweenEnemiesSpawn;
        }

        if (wave > 5 && enemiesLeft == 0)
        {
            //restart.text = "Victory";
            restartButton.SetActive(true);
        }


    }

    IEnumerator StartWaves()
    {
        // Add a delay before starting the first wave
        yield return new WaitForSeconds(5f);

        // Start the first wave
        NextWave();

        while (true)
        {
            // Wait until all enemies from the current wave are defeated
            yield return new WaitUntil(() => enemiesLeft == 0);
            wave++;

            // Check if wave count exceeds limit
            if (wave > 5)
            {
                yield break; // Stop spawning waves if we've reached the maximum
                
            }

            // Wait for the specified delay between waves
            yield return new WaitForSeconds(timeBetweenWaves);

            // Start the next wave
            NextWave();
        }
    }


    public void NextWave()
    {
        // Determine how many enemies to spawn for this wave
        enemiesNum = EnemiesForWave(wave);
        enemiesLeft += enemiesNum;

        newWave.totalWave--;
        newWave.UpdateWaveDisplay();

        spawnTime = Time.time+timeBetweenEnemiesSpawn; 

        // Now increment wave for the next cycle
        
    }


    private void Spawn()
    {
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
}
