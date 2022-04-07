using System.Collections;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    private bool isPlayerInRange;

    [SerializeField] private GameObject dialogueMark;

    [SerializeField, TextArea(4,6)] private string[] dialogueLines;

    [SerializeField] 

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if  (collision.gameObject.CompareTag("Player")){
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}
