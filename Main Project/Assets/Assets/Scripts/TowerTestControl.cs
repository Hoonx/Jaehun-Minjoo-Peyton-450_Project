using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTestControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static TowerTestControl instance;
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
    public int facing = 1;
    bool mouseTouch;
    public Animator anim;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
        sprite = GetComponent<SpriteRenderer>();
        thisCollider = GetComponent<Collider2D>();
        originalColor = sprite.color;
        anim = GetComponent<Animator>();
        

    }

    
    void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.GetComponent<MouseController>()) {
            mouseTouch = true;
        }
        if (other.gameObject.GetComponent<PlatformController>())
        {
            platformName = other.gameObject.GetComponent<PlatformController>().name;
            platformPosition = other.gameObject.GetComponent<PlatformController>().transform.position;
            facing = other.gameObject.GetComponent<PlatformController>().orientation;
            if (other.gameObject.GetComponent<PlatformController>().filled == false) {
                onPlatform = true;
            }
            else {
                onPlatform = false;
            }
            
        }


    }



    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.GetComponent<PlatformController>())
        {
            platformName = "";
            platformPosition = new Vector3(0, 0, 0);
            onPlatform = false;
           

        }
        if (other.gameObject.GetComponent<MouseController>()) {
            mouseTouch = false;
        }

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

            if (Input.GetMouseButtonDown(0) && mouseTouch && mouse.holding == false){
                sprite.color = new Color(1, 0, 0, .75f);
                sprite.sprite = forward;
                selected = true;
                mouse.holding = true;
            }
        }
        else {
            
            transform.position = mousePositionInWorld;
            transform.position += new Vector3(0, -0.4f, 0);

            if (onPlatform)
            {
                sprite.color = new Color(0, 1, 0, .75f);

            }
            else
            {
                sprite.color = new Color(1, 0, 0, .75f);

            }
            if (Input.GetMouseButtonDown(0) && onPlatform)
            {
                
               if (facing > 1)
                {

                    anim.SetInteger("Facing", 2);
                }
                else if (facing < 1)
                {

                    anim.SetInteger("Facing", 0);
                }
                else {
                    
                    anim.SetInteger("Facing", 1);
                } 
                Debug.Log("click");
                mouse.holding = false;
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
