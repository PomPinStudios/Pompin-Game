using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideShop : MonoBehaviour
{
    public Canvas shopCanvas;
    [HideInInspector]
    public Canvas inventory;
    [HideInInspector]
    public GameObject playerInventory;
    [HideInInspector]
    public GameObject inventoryManager;
    [HideInInspector]
    public ShowHideInventory showHideInventory;

    private bool shown = false;
    [HideInInspector]
    public bool onColission = false;
    public bool afterClose = false;

    public void Start() {
        playerInventory = GameObject.Find("Inventory");
        inventoryManager = GameObject.Find("InventoryManager");
        showHideInventory = inventoryManager.GetComponent<ShowHideInventory>();
    }
    public void ClosePanel()
    {
        shopCanvas.gameObject.SetActive(false);
        playerInventory.GetComponent<Canvas>().enabled = false;
        showHideInventory.shopOpen = false;
        afterClose = true;
    }

    private void Update() {
        if(onColission){
            if (Input.GetButtonDown("Interactive"))        
            {
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
        if(this.enabled)
        {
            onColission = true;
            showHideInventory.shopOpen = true;
            playerInventory.GetComponent<Canvas>().enabled = false;
            showHideInventory.stats.SetActive(false);
            showHideInventory.shown = false;
            afterClose = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(this.enabled)
        {
            showHideInventory.shopOpen = false;
            shown = false;
            onColission = false;
            shopCanvas.gameObject.SetActive(false);
            playerInventory.GetComponent<Canvas>().enabled = false;
            afterClose = false;
        }
    }
}
