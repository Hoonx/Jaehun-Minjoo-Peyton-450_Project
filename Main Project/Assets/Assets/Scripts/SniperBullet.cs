using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyInteraction enemy = collision.gameObject.GetComponent<EnemyInteraction>();
        if (enemy != null)
        {
            if (!hasHit)
            {
                enemy.takeDamage(damage);
                damage /= 1.5f;
                hasHit = true;
            }
            else
            {
                enemy.takeDamage(damage);
            }
        }

        if (collision.gameObject.layer == 13)
        {
            Debug.Log("Collided with Boundary");
            Destroy(gameObject);
            return;
        }
    }
}
