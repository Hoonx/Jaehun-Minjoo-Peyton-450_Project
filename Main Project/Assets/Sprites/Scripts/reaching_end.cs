using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class reaching_end : MonoBehaviour
{
    public int cryptHealth = 3;
    public GameObject restartButton;
    public Text healthText;

    private void Start()
    {
        Time.timeScale = 1;
        restartButton.SetActive(false);
        UpdateHealthDisplay();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject && collision.gameObject.tag == "enemy") {
            Debug.Log("End Reached");
            cryptHealth -= 1;
            Spawner.instance.enemiesLeft--;
            UpdateHealthDisplay();


        }
    }
   
    void Update() {
        if (cryptHealth <= 0)
        {
            // Reset Level
            Time.timeScale = 0;
            restartButton.SetActive(true);
            UpdateHealthDisplay();

        }
        
        
    }

    public void UpdateHealthDisplay()
    {
        healthText.text = "Health: " + cryptHealth.ToString();
    }
}
