using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_SniperTurret : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float dps = 2f;

    private Transform target;
    private float waitTime;

    private void Update() {
        if (target == null) {
            FindTarget();
            return;
        }

        if (!isTargetInRange()) {
            target = null;
        }
        else {
            waitTime += Time.deltaTime;
            if (waitTime >= 1f/dps) {
                fire();
                waitTime = 0f;
            }
        }
    }

    private void fire() {
        GameObject projectileObject = Instantiate(projectile, transform.position, Quaternion.identity);
        J_SniperProjectile projectileScript = projectileObject.GetComponent<J_SniperProjectile>();
        projectileScript.DefineTarget(target);
    }

    private bool isTargetInRange() {
        return Vector2.Distance(target.position, transform.position) <= range;
    }

    private void FindTarget() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, enemyMask);

        if (colliders.Length > 0)
        {
            float closestDistance = float.MaxValue;

            foreach (Collider2D collider in colliders)
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    target = collider.transform;
                }
            }
        }
        else
        {
            target = null;
        }
    }
}
