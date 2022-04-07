using System.Collections;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;

   private bool isPlayerInRange;

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = true;
            dialogueMark.
            Debug.Log("Se puede iniciar un dialogo");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if  (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = false;
            Debug.Log("No se puede iniciar un dialogo");
        }
    }
}
