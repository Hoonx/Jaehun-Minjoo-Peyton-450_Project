using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    // Enemy Health
    public float health = 15;
    public int enemiesKilled = 0;
    public BuyButton buy;
    public int timer = 0;

    // How Much Money the Enemy Drops
    private int reward = 25; //Place holder to test out implementation, can change reward money later



    // Start is called before the first frame update
    private void Start()
    {
        buy = FindObjectOfType<BuyButton>();
    }

    public void takeDamage(float x)
    {
        health -= x;
        Debug.Log(health);
        if (health <= 0) {
            death();
        }
    }

    private void death() 
    {
        Destroy(transform.gameObject);
        Spawner.instance.enemiesLeft--;
        enemiesKilled++;
        buy.AddMoney(reward);

    }

}
