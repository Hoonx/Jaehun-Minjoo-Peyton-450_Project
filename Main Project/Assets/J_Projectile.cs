using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Transform target;
    [SerializeField] private float speed = 5f;

    public void defineTarget(Transform _target) {
        target = _target;
    }

    private void FixedUpdate() {
        if (!target) {
            return;
        }
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D coll) {
        Destroy(gameObject);
    }
}
