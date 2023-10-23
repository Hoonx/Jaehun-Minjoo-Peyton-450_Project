using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageProjectile : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float speed = 10f;
    private Transform target;

    public void setTarget(Transform currentTarget) {
        target = currentTarget;
    }
    private void FixedUpdate() {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
}
