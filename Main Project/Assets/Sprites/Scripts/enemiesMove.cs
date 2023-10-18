using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMove : MonoBehaviour
{
    public Rigidbody2D _rb;
    public float moveSpeed = 5f;
    public Spawner spawner;
    


    private Transform target;
    private int pathIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= .1f)
        {
            pathIndex++;
            if (pathIndex == LevelManager.main.path.Length)
            {
                Destroy(gameObject);
                spawner.enemiesLeft--;
                return;
            }
            else
            {

                target = LevelManager.main.path[pathIndex];
            }
        }

        
    }

    void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        _rb.velocity = direction * moveSpeed;        
    }
}
