using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTowerScript : MonoBehaviour
{
    TowerTestControl tower;
    Animator attackAnim;
    private void Start()
    {
        tower = GetComponent<TowerTestControl>();
        attackAnim = GetComponent<Animator>();


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemiesMove>() && tower.selected == false) {
            other.gameObject.GetComponent<EnemiesMove>().moveSpeed /= 1.6f;
            Debug.Log("slowed" + other.gameObject.GetComponent<EnemiesMove>().moveSpeed);
            attackAnim.SetBool("Trigger", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemiesMove>() && tower.selected == false)
        {
            other.gameObject.GetComponent<EnemiesMove>().moveSpeed *= 1.6f;
            attackAnim.SetBool("Trigger", false);
        }
    }
}
