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
    private float timeBetweenWaves = 10f;
    public int enemiesLeft; //enemies left that are alive
    public GameObject restartButton;
    public Text restart;
    public EnemiesMove enemyMov;
    public EnemyInteraction enemyHel;
    public Coroutine waveCoroutine;
    public Button nextwaveButton;
    public static Spawner instance;
    public bool skip = true;

    public NewWave newWave;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        enemyMov.moveSpeed = 1;
        enemyHel.health = 10;
        waveCoroutine = StartCoroutine("StartWaves");
    }

    void Update()
    {
        // Check if we should spawn
        if (enemiesNum > 0 && Time.time >= spawnTime)
        {
            nextwaveButton.interactable = false;
            Spawn();
            enemiesNum--;
            spawnTime = Time.time + timeBetweenEnemiesSpawn;
        } else if (enemiesNum == 0 && enemiesLeft == 0)
        {
            nextwaveButton.interactable = true; 
        }


        //if (wave >= 5 && enemiesLeft == 0)
        //{
        //    restart.text = "Victory:Restart?";
        //    restartButton.SetActive(true);
        //}


    }

    IEnumerator StartWaves()
    {
        yield return new WaitForSeconds(2f);
        // Start the first wave
        NextWave();

        while (skip == true)
        {
            // Wait until all enemies from the current wave are defeated
            yield return new WaitUntil(() => enemiesLeft == 0);


            yield return new WaitForSeconds(timeBetweenWaves);

            wave++;
            // Start the next wave
            NextWave();

        }
    }


    public void NextWave()
    {
        // Determine how many enemies to spawn for this wave
        enemiesNum = EnemiesForWave(wave);
        enemiesLeft += enemiesNum;

        //newWave.totalWave--;
        newWave.UpdateWaveDisplay();

        spawnTime = Time.time+timeBetweenEnemiesSpawn;
        enemyHel.health *= 1.25f;
        enemyMov.moveSpeed += .75f;


       
    }


    public void StopCurrentWave()
    {
        if (waveCoroutine != null)
        {
            StopCoroutine(waveCoroutine);
            waveCoroutine = null;
        }
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
