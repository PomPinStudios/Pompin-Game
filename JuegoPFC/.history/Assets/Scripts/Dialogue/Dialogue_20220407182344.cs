using System.Collections;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
   private bool isPlayerInRange;

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.gameObject.c)
        isPlayerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInRange = false;
    }
}
