using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesMove : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= .1f)
        {
            pathIndex++;
        }
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(target.position, transform.position) <= .1f)
        {
            pathIndex++;
            target = LevelManager.main.path[pathIndex];
        }

        if (pathIndex == LevelManager.main.path.Length)
        {
            Destroy(gameObject);
            return;

        } else
        {
            target = LevelManager.main.path[pathIndex];
        }
        Vector2 direction = (   target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;        
    }
}
