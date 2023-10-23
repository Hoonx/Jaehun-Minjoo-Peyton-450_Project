using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    
    
    
    public SpriteRenderer currentSprite;
    public Sprite staticSprite;
    public Sprite holdSprite;
    public Sprite grabSprite;
    
    public bool holding = false;
    void Start()
    {
        Cursor.visible = false;
        currentSprite = GetComponent<SpriteRenderer>();
        
        
        

    }
    // Update is called once per frame
    void OnCollisionStay2D(Collision2D other) {

        if (other.gameObject.GetComponent<TowerTestControl>())
        {
            if (holding)
            {
                currentSprite.sprite = grabSprite;
            }
            else
            {
                currentSprite.sprite = holdSprite;
            }
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        currentSprite.sprite = staticSprite;
    }

    void Update()
    {
      
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePositionInWorld.z = 0;
        mousePositionInWorld.x += .03f;
        mousePositionInWorld.y -= .03f;
        transform.position = mousePositionInWorld;
       
        
    }
    
}
