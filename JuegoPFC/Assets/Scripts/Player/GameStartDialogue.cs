using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartDialogue : MonoBehaviour
{
    public FirstDialogue dialogo;
    public bool onCollision;

    // Update is called once per frame
    void Update()
    {
        if (onCollision && dialogo.finishSpeaking)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        onCollision = true;
        ShouldLoadInventary.gameStart = true;
    }
}
