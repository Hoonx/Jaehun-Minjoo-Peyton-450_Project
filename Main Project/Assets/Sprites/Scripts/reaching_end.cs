using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class reaching_end : MonoBehaviour
{
    public int health = 3;
    public GameObject restartButton;
    public Text healthText;

    private void Start()
    {
        restartButton.SetActive(false);
        UpdateHealthDisplay();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject && collision.gameObject.tag == "enemy") {
            Debug.Log("End Reached");
            health -= 1;
            UpdateHealthDisplay();


        }
    }
   
    void Update() {
        if (health <= 0)
        {
            // Reset Level
            Time.timeScale = 0;
            restartButton.SetActive(true);
            UpdateHealthDisplay();

        }
        else {
            Time.timeScale = 1;
        }
        
    }

    public void UpdateHealthDisplay()
    {
        healthText.text =  health.ToString();
    }
}