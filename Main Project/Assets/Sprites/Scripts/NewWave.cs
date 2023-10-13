using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWave : MonoBehaviour
{
    public Spawner spawner;
    public int totalWave = 5;

    private void Awake()
    {
        // Initialize the 'spawner' reference in Awake
        spawner = FindObjectOfType<Spawner>();

    }

    public void OnButtonPress()
    {
        if (spawner != null)
        {
            Debug.LogError("success");
            if (totalWave >=0)
            {
                spawner.wave++;
                spawner.StartWave();
                totalWave--;
            }
            
        }
        else
        {
            Debug.LogError("Spawner object not assigned or not found in the scene.");
        }
    }
}
