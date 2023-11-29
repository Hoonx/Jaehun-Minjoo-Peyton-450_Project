using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_SniperProjectile : MonoBehaviour
{
    private bool hasHit = false;
    private Transform target;
    [SerializeField] private float damage = 5;
    [SerializeField] private float speed = 20;
    [SerializeField] private Rigidbody2D rb;

    public void DefineTarget(Transform _target)
    {
        target = _target;
    }

    private void Start() {
        if (target != null) {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else {
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!hasHit)
        {
            collision.gameObject.GetComponent<J_Health>().TakeDamage(damage);
            damage /= 1.5f;
            hasHit = true;
        }
        else {
            collision.gameObject.GetComponent<J_Health>().TakeDamage(damage);
        }
    }
}
