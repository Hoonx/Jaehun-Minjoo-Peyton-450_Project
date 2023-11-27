using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInteraction : MonoBehaviour
{
    // Enemy Health
    // public float health = 15;
    public int enemiesKilled = 0;
    public BuyButton buy;
    public int timer = 0;

    // Health / HealthBar
    public float health;
    public float maxHealth = 15;
    public HealthBar HealthBar;

    // How Much Money the Enemy Drops
    private int reward = 25; //Place holder to test out implementation, can change reward money later

    // public HealthBar healthBarPrefab;
    // private HealthBar healthBarInstance;
    // private Image healthBarFill;

    void Start() {
        health = maxHealth;
        HealthBar.SetHealth(health, maxHealth);
        // healthBarInstance = Instantiate(healthBarPrefab, FindObjectOfType<Canvas>().transform);
        // healthBarInstance.targetTransform = transform;
        // healthBarFill = healthBarInstance.transform.Find("HealthFill").GetComponent<Image>();
    }

    // void Update() {
    //     healthBarInstance.transform.position = transform.position + new Vector3(0f, 2f, 0f);
    // }


    public void takeDamage(float x)
    {
        health -= x;
        HealthBar.SetHealth(health, maxHealth);
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
        BuyButton.instance.AddMoney(reward);
        // Destroy(healthBarInstance);
    }

    // private void SetHealthBar() {
    //     float fillAmount = health / 15f;
    //     healthBarFill.fillAmount = fillAmount;
    // }
}
