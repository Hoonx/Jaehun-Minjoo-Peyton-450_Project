using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool filled;
    public TowerTestControl tower;
    Collider2D thisCollider;
    public Collider2D towerCollider;
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (thisCollider.IsTouching(towerCollider) && tower.selected == false)
        {
            filled = true;
        }
        else {
            filled = false;
        }
    }
}
