using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged_Tower : MonoBehaviour
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
        Spider_Projectile projectileScript = projectileObject.GetComponent<Spider_Projectile>();
        projectileScript.defineTarget(target);
    }

    private bool isTargetInRange() {
        return Vector2.Distance(target.position, transform.position) <= range;
    }

    private void FindTarget() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, range, (Vector2) transform.position, 0f, enemyMask);

        if (hits.Length > 0) {
            target = hits[0].transform;
        }
    }
}
