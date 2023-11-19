using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{

    SpriteRenderer sprite;
    public Sprite closed;
    public Sprite open;
    // Start is called before the first frame update
    public MouseController mouse;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        
        if (collision.gameObject.GetComponent<TowerTestControl>()) {
            Debug.Log("touch");
            sprite.sprite = open;
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("click");
                Destroy(collision.gameObject);
                mouse.holding = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TowerTestControl>()) { 
             sprite.sprite = closed;
        }
        
    }
}

