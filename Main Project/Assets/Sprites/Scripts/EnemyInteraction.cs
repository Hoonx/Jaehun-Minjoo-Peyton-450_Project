using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    // Enemy Health
    public float health = 15;
    // How Much Money the Enemy Drops
    //private int reward;



    // Start is called before the first frame update


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
        Spawner.instance.enemiesLeft--;
    }

}
