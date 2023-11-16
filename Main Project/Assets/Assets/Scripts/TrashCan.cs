using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    // Start is called before the first frame update
    public MouseController mouse;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TowerTestControl>()) {
            Debug.Log("touch");
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("click");
                Destroy(collision.gameObject);
                mouse.holding = false;
            }
        }
    }
}

