using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTestControl : MonoBehaviour
{
    // Start is called before the first frame update
    public bool selected = false;
    SpriteRenderer sprite;
    
    Collider2D thisCollider;
    public Collider2D mouseCollider;
    Color originalColor;
    Collider2D platformCollider;
    bool onPlatform = false;
    string platformName;
    Vector3 platformPosition;
    public MouseController mouse;
    public Sprite forward;
    public Sprite right;
    public Sprite left;
    public int facing;

    void Start()
    {
        
        sprite = GetComponent<SpriteRenderer>();
        thisCollider = GetComponent<Collider2D>();
        originalColor = sprite.color;
       
        
    }
    

    void OnCollisionStay2D(Collision2D other) {

        if (other.gameObject.GetComponent<platformController>())
        {
            platformName = other.gameObject.GetComponent<platformController>().name;
            platformPosition = other.gameObject.GetComponent<platformController>().transform.position;
            facing = other.gameObject.GetComponent<platformController>().orientation;
            onPlatform = other.gameObject.GetComponent<platformController>();
        }
    }



    void OnCollisionExit2D(Collision2D other) {
        platformName = "";
        platformPosition = new Vector3(0, 0, 0);
        onPlatform = false;
    }
    //Note: Code Commented out does not currently function
    // Update is called once per frame
    void Update()
    {
        //filled = platform.filled;
        //getting mouse input, will be changed to follow mouseController
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePositionInWorld.z = 0;
        //Figuring out if a Unit has been selected and if it can be placed, will be changed to be universal among all platforms
        if (!selected) {

            if (Input.GetMouseButtonDown(0) && thisCollider.IsTouching(mouseCollider) && mouse.isSelected == false){
                sprite.color = new Color(1, 0, 0, .75f);
                sprite.sprite = forward;
                selected = true;
            }
        }
        else {
            
            transform.position = mousePositionInWorld;
            transform.position += new Vector3(0, -0.4f, 0);

            if (onPlatform /*&& !filled*/)
            {
                sprite.color = new Color(0, 1, 0, .75f);

            }
            else
            {
                sprite.color = new Color(1, 0, 0, .75f);

            }
            if (Input.GetMouseButtonDown(0) && onPlatform /*&& !filled*/)
            {
                if (facing > 1)
                {
                    sprite.sprite = left;
                }
                else if (facing < 1)
                {
                    sprite.sprite = right;
                }
                else {
                    sprite.sprite = forward;
                }
                
                
                transform.position = platformPosition;
                transform.position += new Vector3(0, 0.4f, 0);
                selected = false;
                sprite.color = originalColor;
            }
            else {
                selected = true;
            }
        }
            
       
    }
}
