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
    public Animator anim;
    Vector2 previousDirection;



    // Start is called before the first frame update
    void Start()
    {
        target = LevelManager.main.path[pathIndex];
        anim = GetComponent<Animator>();
        previousDirection.y = 0;
        previousDirection.x = 0;
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
                Spawner.instance.enemiesLeft--;
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
        bool forwards = true;
        Vector2 direction = (target.position - transform.position).normalized;
        Debug.Log(direction.x);
        if (direction != previousDirection)
        {
            if (forwards)
            {
                forwards = false;
                anim.SetBool("WalkForward", false);
            }
            else {
                forwards = true;
                anim.SetBool("WalkForward", true);
            }
            
        }
        _rb.velocity = direction * moveSpeed;   
        previousDirection = direction;
    }
}
