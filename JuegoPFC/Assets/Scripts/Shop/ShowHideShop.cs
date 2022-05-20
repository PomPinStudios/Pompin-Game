using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideShop : MonoBehaviour
{
    public Canvas shopCanvas;
    private Canvas inventory;
    private GameObject playerInventory;
    private GameObject inventoryManager;
    private ShowHideInventory showHideInventory;

    private bool shown = false;
    private bool onColission = false;
    public bool afterClose = false;

    private void Start() {
        playerInventory = GameObject.Find("Inventory");
        inventoryManager = GameObject.Find("InventoryManager");
        showHideInventory = inventoryManager.GetComponent<ShowHideInventory>();
    }
    public void ClosePanel()
    {
        // shown = !shown;
        shopCanvas.gameObject.SetActive(false);
        playerInventory.GetComponent<Canvas>().enabled = false;
        showHideInventory.shopOpen = false;
        Debug.Log(shown);
        afterClose = true;
    }

    private void Update() {
        if(onColission){
            if (Input.GetButtonDown("Interactive"))        
            {
                Debug.Log(shown);
                if(afterClose)
                {
                    shopCanvas.gameObject.SetActive(true);
                }
                else
                {
                    shopCanvas.gameObject.SetActive(!shown);
                }
                playerInventory.GetComponent<Canvas>().enabled = !playerInventory.GetComponent<Canvas>().enabled;
                shown = !shown;
            }
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        onColission = true;
        showHideInventory.shopOpen = true;
        playerInventory.GetComponent<Canvas>().enabled = false;
        showHideInventory.stats.SetActive(false);
        showHideInventory.shown = false;
        afterClose = false;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        showHideInventory.shopOpen = false;
        shown = false;
        onColission = false;
        shopCanvas.gameObject.SetActive(false);
        playerInventory.GetComponent<Canvas>().enabled = false;
        afterClose = false;
    }
}
