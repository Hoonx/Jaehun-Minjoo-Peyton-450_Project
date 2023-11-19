using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Transform target;
    [SerializeField] private float speed = 5f;
    [SerializeField] private int damage = 1;

    public void defineTarget(Transform _target)
    {
        target = _target;
    }

    private void FixedUpdate()
    {
        if (!target)
        {
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            coll.gameObject.GetComponent<J_Health>().TakeDamage(damage);
        }
    }
}