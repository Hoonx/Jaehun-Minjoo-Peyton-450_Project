using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Health : MonoBehaviour
{
    [SerializeField] private int health = 5;

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
