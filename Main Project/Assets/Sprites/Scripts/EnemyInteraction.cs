using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    // Enemy Health
    public float health = 15;
    // How Much Money the Enemy Drops
    private int reward;
    // How Much Damage the Enemy Does if it Reaches the End
    private int damage = 1;
    public Spawner spawner;


    // Start is called before the first frame update
    void Start()
    {
        // Call enemy Setup
        
    }

    private void enemySetup()
    {
        // We should implement the movement here and below with additional functions.
    }

    public void takeDamage(float x)
    {
        health -= x;
        if (health <= 0) {
            death();
        }
    }

    private void death() 
    {
        Destroy(transform.gameObject);
        //spawner.enemiesLeft--;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
