using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour
{

    public GameObject[] itemInStore;
    public GameObject shopCanvas;
    Inventory inventory;
    public bool sellItems;

    public GameObject playerInventory;
    private bool shown = false;
    private bool onColission = false;
    private void Start() 
    {
        inventory = gameObject.GetComponent<Inventory>();
        Debug.Log(itemInStore.Length);
        SetUpStore();
    }

    private void Update() {
        if(onColission){
            if (Input.GetButtonDown("Interactive"))        
            {
                shopCanvas.SetActive(!shown);
                playerInventory.SetActive(!shown);
                shown = !shown;
            }
        }    
    }
    private void SetUpStore()
    {
        for (int i = 0; i < itemInStore.Length; i++)
        {
            GameObject itemToSell = Instantiate(itemInStore[i], inventory.slots[i].transform.position, Quaternion.identity);
            itemToSell.transform.SetParent(inventory.slots[i].transform, false);
            itemToSell.transform.localPosition = new Vector3(0, 0, 0);
            itemToSell.name = itemToSell.name.Replace("(Clone)", "");
        }
        
    }

    public void IsSelleingItems()
    {
        sellItems = !sellItems;
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     onColission = true;
    // }
    // void OnTriggerExit2D(Collider2D other)
    // {
    //     shown = !shown;
    //     onColission = false;
    //     shopCanvas.SetActive(false);
    //     playerInventory.SetActive(false);
    // }
    
}
