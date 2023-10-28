using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class J_Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [Header("Attribute")]
    [SerializeField] private float range = 5f;
    [SerializeField] private float rotationSpeed = 200;
    [SerializeField] private LayerMask enemyMask;
    private Transform target;

    private void OnDrawGizmosSelected() {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, transform.forward, range);
        {
            
        }
    }

    private void Update() {
        if (target == null) {
            FindTarget();
            return;
        }
        RotateTowardTarget();
    }

    private void isTargetInRange() {

    }

    private void RotateTowardTarget() {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void FindTarget() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, range, (Vector2) transform.position, 0f, enemyMask);

        if (hits.Length > 0) {
            target = hits[0].transform;
        }
    }
}
