using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTestControl : MonoBehaviour
{
    // Start is called before the first frame update
    bool selected = false;
    SpriteRenderer sprite;
    Collider2D thisCollider;
    public Collider2D mouseCollider;
    Color originalColor;
    public Collider2D platformCollider;
    bool onPlatform = false;
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        thisCollider = GetComponent<Collider2D>();
        originalColor = sprite.color;
        
    }
   


    // Update is called once per frame
    void Update()
    {
        
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePositionInWorld.z = 0;
        if (!selected) {

            if (Input.GetMouseButtonDown(0) && thisCollider.IsTouching(mouseCollider)){
                sprite.color = new Color(1, 0, 0, .75f);
                selected = true;
            }
        }
        else {
            
            transform.position = mousePositionInWorld;
            transform.position += new Vector3(0, -0.4f, 0);
            if (thisCollider.IsTouching(platformCollider))
            {
                sprite.color = new Color(0, 1, 0, .75f);
                onPlatform = true;
            }
            else {
                sprite.color = new Color(1, 0, 0, .75f);
                onPlatform = false;
            }

            if (Input.GetMouseButtonDown(0) && onPlatform) {
                transform.position = GameObject.Find("Platform").transform.position;
                transform.position += new Vector3(0, 0.5f, 0);
                selected = false;
                sprite.color = originalColor;
            }
        }
            
       
    }
}
