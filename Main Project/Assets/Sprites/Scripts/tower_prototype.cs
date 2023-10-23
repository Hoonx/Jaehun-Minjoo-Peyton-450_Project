using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_prototype : MonoBehaviour

{
    TowerTestControl tower;
    public Animator attackAnim;
    [SerializeField] private float towerRange = 5f;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float firerate = 1f;
    private float nextFire;
    [SerializeField] private int damage = 1;
    private Transform currentTarget;

    private void Start()
    {
        tower = GetComponent<TowerTestControl>();
        attackAnim = GetComponent<Animator>();
       

    }

    private void Update() {
        if (currentTarget == null) {
            locateTarget();
            return;
        }
        if (!targetInRange()) {
            currentTarget = null;
        }
        else {
            nextFire += Time.deltaTime;
            if (nextFire >= 1f / firerate) {
                shoot();
                nextFire = 0f;
            }
        }
    }

    private void shoot() {
        Debug.Log("Shoot");
        // GameObject projectile = Instantiate(projectile, )
    }

    private void locateTarget() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, towerRange, (Vector2) transform.position, 0f, enemyMask);
        if (hits.Length > 0) {
            currentTarget = hits[0].transform;
        }
    }

    private bool targetInRange() {
        return Vector2.Distance(currentTarget.position, transform.position) <= towerRange;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
         collision.gameObject.GetComponent<Health>().takeDamage(damage);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
         if (collision.gameObject.tag == "enemy") {
             if (tower.selected) { }
             else
             {
                 attackAnim.SetBool("Trigger", true);
             }
         }
     }

    private void OnTriggerExit2D(Collider2D collision) {
        attackAnim.SetBool("Trigger", false);
    }
}
