using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWave : MonoBehaviour
{
    public Spawner spawner;

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
            spawner.wave++;
            spawner.StartWave();
            
        }
        else
        {
            Debug.LogError("Spawner object not assigned or not found in the scene.");
        }
    }
}
