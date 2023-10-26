using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTowerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemiesMove>()) {
            other.gameObject.GetComponent<EnemiesMove>().moveSpeed /= 2;
            Debug.Log("slowed" + other.gameObject.GetComponent<EnemiesMove>().moveSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemiesMove>())
        {
            other.gameObject.GetComponent<EnemiesMove>().moveSpeed *= 2;
        }
    }
}
