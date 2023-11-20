using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Health : MonoBehaviour
{
    public float health;
    public float maxHealth = 5;
    public J_HealthBar HealthBar;

    void Start() {
        health = maxHealth;
        HealthBar.SetHealth(health, maxHealth);
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
