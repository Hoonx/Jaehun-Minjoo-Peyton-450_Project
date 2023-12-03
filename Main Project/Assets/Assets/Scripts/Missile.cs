using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Transform target;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 1;
    [SerializeField] private float SplashRange = 1;

    public void DefineTarget(Transform _target)
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
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<MouseController>() == false && coll.gameObject.GetComponent<PlatformController>() == false)
        {
            if (SplashRange > 0)
            {
                var hitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
                foreach (var hitCollider in hitColliders)
                {
                    var enemy = hitCollider.GetComponent<EnemyInteraction>();
                    if (enemy)
                    {
                        var closestPoint = hitCollider.ClosestPoint(transform.position);
                        var distance = Vector3.Distance(closestPoint, transform.position);
                        var damagePercent = Mathf.InverseLerp(SplashRange, 0, distance);
                        enemy.takeDamage(damagePercent * damage);
                    }
                }
            }
            var enemyInteraction = coll.gameObject.GetComponent<EnemyInteraction>();
            if (enemyInteraction != null)
            {
                enemyInteraction.takeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}