using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesMove : MonoBehaviour
{
    public Rigidbody2D _rb;
    public float moveSpeed = 5f;
    


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
            target = LevelManager.main.path[pathIndex];
            //Destroy(gameObject)
        }
    }

    void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        _rb.velocity = direction * moveSpeed;        
    }
}
