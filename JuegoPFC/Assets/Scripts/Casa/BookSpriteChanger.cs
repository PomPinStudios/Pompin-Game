using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpriteChanger : MonoBehaviour
{
    public bool onCollision;
    public SpriteRenderer sprite;
    public Sprite spriteOpen;
    public Sprite spriteClose;


    void Start()
    {
        
    }

    void Update()
    {
        if(onCollision){
            if (Input.GetButtonDown("Interactive"))
            {
                sprite.sprite = spriteOpen;
            } 
        }
        if(!onCollision){
            sprite.sprite = spriteClose;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        onCollision = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onCollision = false;
    }
}
