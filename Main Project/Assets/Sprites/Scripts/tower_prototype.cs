using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_prototype : MonoBehaviour

{
    TowerTestControl tower;
    public Animator attackAnim;

    public float firerate;
    float nextFire;
    private GameObject currentTarget;
    private void Start()
    {
        tower = GetComponent<TowerTestControl>();
        attackAnim = GetComponent<Animator>();
       

    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "enemy") {
            if (tower.selected) { }
            else
            {
                if (Time.time > nextFire) {
                    Debug.Log("next fire");
                    nextFire = Time.time + firerate;
                    collision.gameObject.GetComponent<EnemyInteraction>().takeDamage(5);
                    attackAnim.SetBool("Trigger", true);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        attackAnim.SetBool("Trigger", false);
    }
}
