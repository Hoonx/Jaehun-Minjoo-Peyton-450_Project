using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_prototype : MonoBehaviour

{
    public static tower_prototype instance;
    TowerTestControl tower;
    public Animator attackAnim;
    //[SerializeField] private float towerRange = 5f;
    //[SerializeField] private LayerMask enemyMask;
    //[SerializeField] private float firerate = 1f;
    private float nextFire;
    public int timeModify;
    public int damage = 1;
    //private Transform currentTarget;
    //public GameObject projectilePrefab;


    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        tower = GetComponent<TowerTestControl>();
        attackAnim = GetComponent<Animator>();
       

    }

    private void Update() {
       /* if (currentTarget == null) {
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
        }*/
    } 

    /* private void shoot() {
         Debug.Log("Shoot");
         // GameObject projectile = Instantiate(projectile, )
         Instantiate(projectilePrefab, transform.position, Quaternion.identity);
         if (currentTarget.gameObject.tag == "enemy")
         {
             currentTarget.gameObject.GetComponent<EnemyInteraction>().takeDamage(damage);

         }
     } */

    /*  private void locateTarget() {
          RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, towerRange, (Vector2) transform.position, 0f, enemyMask);
          if (hits.Length > 0) {
              currentTarget = hits[0].transform;

          }
      }

      private bool targetInRange() {
          return Vector2.Distance(currentTarget.position, transform.position) <= towerRange;
      }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyInteraction>()) {
            collision.gameObject.GetComponent<EnemyInteraction>().timer = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (tower.selected)
        {
        }
        else
        {
            if (collision.gameObject.GetComponent<EnemyInteraction>())
            {
                if (tower.selected) { }
                else
                {
                    attackAnim.SetBool("Trigger", true);
                    collision.gameObject.GetComponent<EnemyInteraction>().timer += 1;
                    //Debug.Log(collision.gameObject.GetComponent<EnemyInteraction>().timer);
                    if (collision.gameObject.GetComponent<EnemyInteraction>().timer % timeModify == 0)
                    {
                        collision.gameObject.GetComponent<EnemyInteraction>().takeDamage(damage);
                    }

                }


            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyInteraction>()) {
            collision.gameObject.GetComponent<EnemyInteraction>().timer = 0;
            attackAnim.SetBool("Trigger", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
         if (collision.gameObject.GetComponent<EnemyInteraction>()) {
             if (tower.selected) { }
             else
             {
                 attackAnim.SetBool("Trigger", true);
             }
         }
     }

    private void OnTriggerExit2D(Collider2D collision) {
        //attackAnim.SetBool("Trigger", false);
        if (collision.gameObject.tag == "enemy")
        {
            
            
           attackAnim.SetBool("Trigger", false);
            
        }
    }
}
