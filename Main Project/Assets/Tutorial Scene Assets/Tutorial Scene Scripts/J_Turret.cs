using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class J_Turret : MonoBehaviour
{
    [SerializeField] private float range = 5f;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject projectile;
    [SerializeField] private float dps = 2f;

    private Queue<Transform> targetsQueue = new Queue<Transform>();
    private float waitTime;
    private Transform target;

    private void Update()
    {
        if (targetsQueue.Count == 0)
        {
            FindTarget();
            return;
        }

        target = targetsQueue.Peek();

        if (!isTargetInRange())
        {
            targetsQueue.Dequeue();
            return;
        }

        waitTime += Time.deltaTime;
        if (waitTime >= 1f / dps)
        {
            fire();
            waitTime = 0f;
        }
    }

    private void fire()
    {
        GameObject projectileObject = Instantiate(projectile, transform.position, Quaternion.identity);
        J_Projectile projectileScript = projectileObject.GetComponent<J_Projectile>();
        projectileScript.defineTarget(target);
    }

    private bool isTargetInRange()
    {
        if (target == null)
        {
            return false; // The target is considered out of range if it's null
        }

        return Vector2.Distance(target.position, transform.position) <= range;
    }

    private void FindTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, enemyMask);

        foreach (Collider2D collider in colliders)
        {
            if (!targetsQueue.Contains(collider.transform))
            {
                targetsQueue.Enqueue(collider.transform);
            }
        }
    }
}
//     [SerializeField] private float range = 5f;
//     [SerializeField] private LayerMask enemyMask;
//     [SerializeField] private GameObject projectile;
//     [SerializeField] private float dps = 2f;

//     private Transform target;
//     private float waitTime;

//     private void Update() {
//         if (target == null) {
//             FindTarget();
//             return;
//         }

//         if (!isTargetInRange()) {
//             target = null;
//         }
//         else {
//             waitTime += Time.deltaTime;
//             if (waitTime >= 1f/dps) {
//                 fire();
//                 waitTime = 0f;
//             }
//         }
//     }

//     private void fire() {
//         GameObject projectileObject = Instantiate(projectile, transform.position, Quaternion.identity);
//         J_Projectile projectileScript = projectileObject.GetComponent<J_Projectile>();
//         projectileScript.defineTarget(target);
//     }

//     private bool isTargetInRange() {
//         return Vector2.Distance(target.position, transform.position) <= range;
//     }

//     private void FindTarget() {
//         // RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, range, (Vector2) transform.position, 0f, enemyMask);

//         // if (hits.Length > 0) {
//         //     target = hits[0].transform;
//         // }
//     }
// }
