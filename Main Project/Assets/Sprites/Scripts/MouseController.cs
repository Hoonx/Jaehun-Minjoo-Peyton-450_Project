using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    bool isSelected;
    Collider2D thisCollider;
    public Collider2D towerCollider;
    SpriteRenderer currentSprite;
    public Sprite staticSprite;
    public Sprite holdSprite;
    public Sprite grabSprite;
    public TowerTestControl tower;
    bool selected;
    void Start()
    {
        Cursor.visible = false;
        currentSprite = GetComponent<SpriteRenderer>();
        thisCollider = GetComponent<Collider2D>();
        //towerCollider = GetComponent<TowerTestControl>(); 
        

    }
    // Update is called once per frame
    void Update()
    {
        selected = tower.selected;
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePositionInWorld.z = 0;
        transform.position = mousePositionInWorld;
        if (thisCollider.IsTouching(towerCollider) && !selected)
        {
            currentSprite.sprite = holdSprite;
        }
        else if (thisCollider.IsTouching(towerCollider) && selected) {
            currentSprite.sprite = grabSprite;
        }
        else
        {

            currentSprite.sprite = staticSprite;
        }

        
    }
    
}
