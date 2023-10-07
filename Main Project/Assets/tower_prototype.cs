using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_prototype : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "enemy") {
            Debug.Log("Detected");
            collision.gameObject.GetComponent<EnemyInteraction>().takeDamage(5);
        }
    }
}
