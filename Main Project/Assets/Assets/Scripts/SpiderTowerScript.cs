using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTowerScript : MonoBehaviour
{
    TowerTestControl tower;
    private void Start()
    {
        tower = GetComponent<TowerTestControl>();


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemiesMove>() && tower.selected == false) {
            other.gameObject.GetComponent<EnemiesMove>().moveSpeed /= 1.5f;
            Debug.Log("slowed" + other.gameObject.GetComponent<EnemiesMove>().moveSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemiesMove>() && tower.selected == false)
        {
            other.gameObject.GetComponent<EnemiesMove>().moveSpeed *= 1.5f;
        }
    }
}
