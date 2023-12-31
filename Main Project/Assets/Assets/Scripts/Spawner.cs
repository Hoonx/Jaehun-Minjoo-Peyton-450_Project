using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    //public bool skip = true;
    public TMP_Text scoreUI;

    public NewWave newWave;
    public int score =0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        enemyMov.moveSpeed = 1;
        enemyHel.health = 15;
        enemyHel.maxHealth =15;
        waveCoroutine = StartCoroutine("StartWaves");
        score = PlayerPrefs.GetInt("Score");
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
        } else if (enemiesNum <= 0 && enemiesLeft <= 0)
        {
            nextwaveButton.interactable = true;
            if (waveCoroutine == null) // Check if the coroutine is not running
            {
                RestartWaveCoroutine(); // Restart the coroutine if it's not running
            }
        }
        if (wave >= score)
        {
            score = wave;
            PlayerPrefs.SetInt("Score", score);
            scoreUI.text = "Best Score:" + score.ToString();
        }
        scoreUI.text = "Best Score:" + score.ToString();


        //if (wave >= 5 && enemiesLeft == 0)
        //{
        //    restart.text = "Victory:Restart?";
        //    restartButton.SetActive(true);
        //}


    }

    IEnumerator StartWaves()
    {
        //yield return new WaitForSeconds(2f);
        //// Start the first wave
        //NextWave();

        while (true)
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
        enemiesLeft = enemiesNum;

        //newWave.totalWave--;
        newWave.UpdateWaveDisplay();

        spawnTime = Time.time+timeBetweenEnemiesSpawn;
        enemyHel.maxHealth *= 1.5f;
        enemyHel.health *= 1.5f;
        enemyMov.moveSpeed += .5f;

    }


    public void StopCurrentWave()
    {
        if (waveCoroutine != null)
        {
            StopCoroutine(waveCoroutine);
            waveCoroutine = null;
        }
        nextwaveButton.interactable = true;
    }

    public void RestartWaveCoroutine()
    {
        waveCoroutine = StartCoroutine("StartWaves");
    }



    private void Spawn()
    {
        if (Zombie.Length > 0)
        {
            //GameObject spawnedZombies = Zombie[0];
            int randomSpawn = Random.Range(0, Zombie.Length);
            GameObject spawnedZombies = Zombie[randomSpawn];
            Instantiate(spawnedZombies, LevelManager.main.startPoint.position, Quaternion.identity);
            //enemiesLeft++;
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
