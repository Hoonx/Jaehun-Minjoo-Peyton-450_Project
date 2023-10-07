using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D _rb;
    public float moveSpeed = 5f;

    private Transform target;
    private int pathIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        target = LevelControl.main.path[pathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f) {
            pathIndex++;

            if (pathIndex == LevelControl.main.path.Length) {
                Destroy(gameObject);
                return;
            }
            else {
                target = LevelControl.main.path[pathIndex];
            }
        }
    }

    void FixedUpdate() {
        Vector2 direction = (target.position - transform.position).normalized;

        _rb.velocity = direction * moveSpeed;
    }
}
