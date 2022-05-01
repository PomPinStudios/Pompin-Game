using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideShop : MonoBehaviour
{
    public Canvas shopCanvas;
    public Canvas playerInventory;

    private bool shown = false;
    private bool onColission = false;

    public void ClosePanel()
    {
        shown = !shown;
        shopCanvas.gameObject.SetActive(false);
        playerInventory.gameObject.SetActive(false);
    }

    private void Update() {
        if(onColission){
            if (Input.GetButtonDown("Interactive"))        
            {
                shopCanvas.gameObject.SetActive(!shown);
                playerInventory.gameObject.SetActive(!shown);
                shown = !shown;
            }
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        onColission = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        shown = false;
        onColission = false;
        shopCanvas.gameObject.SetActive(false);
        playerInventory.gameObject.SetActive(false);
    }
}
