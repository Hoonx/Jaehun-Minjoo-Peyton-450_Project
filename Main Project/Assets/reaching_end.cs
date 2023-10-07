using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reaching_end : MonoBehaviour
{
    public int health = 3;
    public GameObject restartButton;
    private void Start()
    {
        restartButton.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "enemy") {
            Debug.Log("End Reached");
            health -= 1;
            
        }
    }
   
    void Update() {
        if (health <= 0)
        {
            // Reset Level
            Time.timeScale = 0;
            restartButton.SetActive(true);

        }
        Time.timeScale = 1;
        
    }
}
