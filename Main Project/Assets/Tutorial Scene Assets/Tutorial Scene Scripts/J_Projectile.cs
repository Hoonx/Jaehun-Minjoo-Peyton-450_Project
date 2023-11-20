using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Transform target;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 1;
    [SerializeField] private float SplashRange = 1;

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

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (SplashRange > 0) {
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
            foreach (var hitCollider in hitColliders) {
                var enemy = hitCollider.GetComponent<J_Health>();
                if (enemy) {
                    var closestPoint = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);
                    var damagePercent = Mathf.InverseLerp(SplashRange, 0, distance);
                    enemy.TakeDamage(damagePercent * damage);
                }
            }
        }
        coll.gameObject.GetComponent<J_Health>().TakeDamage(damage);
        Destroy(gameObject);
    }
}