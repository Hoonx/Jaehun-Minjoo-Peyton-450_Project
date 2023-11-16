using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public int orientation;
    public bool filled = false;
    public MouseController mouse;
    // Start is called before the first frame update
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TowerTestControl>()) {
            if (collision.gameObject.GetComponent<TowerTestControl>().selected == false)
            {
                filled = true;
            }
            else {
                if (filled == true)
                {
                    filled = true;
                }
                else {
                    filled = false;
                }
            }
        }
    }



    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.GetComponent<TowerTestControl>()) {
            filled = false;
        }
    }
}