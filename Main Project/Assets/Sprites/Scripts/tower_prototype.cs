using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_prototype : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "enemy") {
            Debug.Log("Detected");
            private float timer = 0f;
            while (collision.gameObject.GetComponent<EnemyInteraction>().health > 0) {
                Debug.Log("Damage Done");
                collision.gameObject.GetComponent<EnemyInteraction>().takeDamage(5);
                // WaitForSeconds(1);
            }
        }
    }
}
