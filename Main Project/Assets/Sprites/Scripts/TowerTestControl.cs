using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTestControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool selected = false;
    SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

    }
   


    bool CollisionDetection(Collision2D other){
        if (other.gameObject.GetComponent<MouseController>()){
        return true;
        }
        else{
          return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
      /*  Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePositionInWorld.z = 0;
        if (!selected) {
            transform.position += new Vector3(0, 0, 0);

            if (Input.GetMouseButtonDown(0) & CollisionDetection()){
                sprite.color = new Color(1, 0, 0, 1);
                selected = true;
            }
        }
        else {
            transform.position = mousePositionInWorld;
            if(Input.GetMouseButtonDown(0)) {
                selected = false;
                sprite.color = new Color(0, 0, 1, 1);
            }
        }
            */
       
    }
}
