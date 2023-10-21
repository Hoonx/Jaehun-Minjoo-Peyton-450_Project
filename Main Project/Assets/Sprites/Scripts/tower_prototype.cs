using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_prototype : MonoBehaviour

{
    TowerTestControl tower;
    public Animator attackAnim;

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
                collision.gameObject.GetComponent<EnemyInteraction>().takeDamage(10);
                attackAnim.SetBool("Trigger", true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        attackAnim.SetBool("Trigger", false);
    }
}
