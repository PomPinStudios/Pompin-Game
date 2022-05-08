using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideShop : MonoBehaviour
{
    public Canvas shopCanvas;
    private Canvas inventory;
    private GameObject playerInventory;

    private bool shown = false;
    private bool onColission = false;

    private void Start() {
        playerInventory = GameObject.Find("Inventory");
    }
    public void ClosePanel()
    {
        shown = !shown;
        shopCanvas.gameObject.SetActive(false);
        playerInventory.GetComponent<Canvas>().enabled = false;
    }

    private void Update() {
        if(onColission){
            if (Input.GetButtonDown("Interactive"))        
            {
                shopCanvas.gameObject.SetActive(!shown);
                playerInventory.GetComponent<Canvas>().enabled = !playerInventory.GetComponent<Canvas>().enabled;
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
        playerInventory.GetComponent<Canvas>().enabled = false;
    }
}
