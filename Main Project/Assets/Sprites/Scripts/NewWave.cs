using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewWave : MonoBehaviour
{
    public Spawner spawner;
    public int totalWave = 5;
    public Text waveText;
   

    private void Awake()
    {
        // Initialize the 'spawner' reference in Awake
        spawner = FindObjectOfType<Spawner>();
        UpdateWaveDisplay();

    }

    public void OnButtonPress()
    {
        if (spawner != null)
        {
            Debug.LogError("success");
            if (totalWave >0)
            {
                spawner.startNextWaveImmediately = true;
                spawner.isSpawn = true;
                //spawner.wave++;
                spawner.NextWave();
                //spawner.wave++;
                totalWave = 5- spawner.wave;
                UpdateWaveDisplay();
            }
            

        }
        else
        {
            Debug.LogError("Spawner object not assigned or not found in the scene.");
        }
    }
    public void UpdateWaveDisplay()
    {
        waveText.text = "Waves Left: " + totalWave.ToString();
    }
}
