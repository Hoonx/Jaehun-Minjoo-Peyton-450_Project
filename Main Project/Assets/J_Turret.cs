using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class J_Turret : MonoBehaviour
{
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private float range = 5f;
    [SerializeField] private float rotationSpeed = 200;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float dps = 2f;

    private Transform target;
    private float waitTime;

    // private void OnDrawGizmosSelected() {
    //     Handles.color = Color.red;
    //     Handles.DrawWireDisc(transform.position, transform.forward, range);
    // }

    private void Update() {
        if (target == null) {
            FindTarget();
            return;
        }
        RotateTowardTarget();
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
        GameObject projectileObject = Instantiate(projectile, firePoint.position, Quaternion.identity);
        J_Projectile projectileScript = projectileObject.GetComponent<J_Projectile>();
        projectileScript.defineTarget(target);
    }

    private bool isTargetInRange() {
        return Vector2.Distance(target.position, transform.position) <= range;
    }

    private void RotateTowardTarget() {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        rotationPoint.rotation = Quaternion.RotateTowards(rotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void FindTarget() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, range, (Vector2) transform.position, 0f, enemyMask);

        if (hits.Length > 0) {
            target = hits[0].transform;
        }
    }
}
