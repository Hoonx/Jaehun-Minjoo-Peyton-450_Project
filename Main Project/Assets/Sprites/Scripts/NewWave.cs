using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewWave : MonoBehaviour
{
    public Spawner spawner;
    //public int totalWave = 5;
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
            spawner.skip = false;
            Debug.LogError("success");
            spawner.wave++;
            //spawner.StopCurrentWave();
            
            UpdateWaveDisplay();
            spawner.NextWave();
            spawner.skip = true;
        }
        else
        {
            Debug.LogError("Spawner object not assigned");
        }
    }
    public void UpdateWaveDisplay()
    {
        waveText.text = "Waves: " + spawner.wave.ToString();
    }
}
