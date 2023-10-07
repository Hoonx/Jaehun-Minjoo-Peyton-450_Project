using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewWave;

public class reaching_end : MonoBehaviour
{
    public int health = 3;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "enemy") {
            Debug.Log("End Reached");
            health -= 1;
        }
    }

    void update {
        if (health <= 0) {
            // Reset Level
            spawner.StartWave;
        }
    }
}
