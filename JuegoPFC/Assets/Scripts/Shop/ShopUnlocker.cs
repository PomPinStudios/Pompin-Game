using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShopUnlocker : MonoBehaviour
{
    private Dialogue dialogue;
    private List<string> dialogueElements;
    private Inventory inventory;
    private InventorySingleton inventorySingleton;
    private GameObject[] slots;
    private ShowHideShop showHideShop;
    public GameObject dialog;
    
    // Start is called before the first frame update
    void Start()
    {
        inventorySingleton = InventorySingleton.instance;
        inventory = inventorySingleton.GetComponent<Inventory>();
        slots = inventory.slots;
        showHideShop = gameObject.GetComponent<ShowHideShop>();
        dialogue = gameObject.GetComponentInChildren<Dialogue>();
        dialogueElements = dialogue.dialogueLines;
        dialogueElements.Add("Tendero: Buenos dias joven, necesito que me ayudes a recuperar algo especial para mi.");
        dialogueElements.Add("Tendero: Necesito que encuentres mi peluquín, que sin el me siento raro.");
        dialogueElements.Add("Tendero: La ultima vez que lo vi, fue en el campo de trigo que esta al sur del pueblo");
        dialogueElements.Add("Tendero: Si lo recuperas podras hacer uso de mi tienda.");
        dialogueElements.Add("Tendero: Gracias!");
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue.firstInteraction) searchObject();
    }

    private bool hasHair;
    private Transform item;
    void searchObject(){
        if (Input.GetButtonDown("Interactive"))
        {
            if (hasHair)
            {
                dialogue.enabled = false;
                dialogueElements.Clear();
                dialogueElements.Add("Tendero: Muchas Gracias joven");
                dialogueElements.Add("Tendero: Ahora puedas usar mi tienda cuando quieras");
                dialogueElements.Add("Tendero: Hasta pronto");
                dialogue.startDialogue();
                try{
                    inventory.UseInventoryItems(item.name, 1);
                }catch (Exception e)
                {e.ToString();}
                if(dialogue.finishSpeaking)
                {
                    showHideShop.enabled = true;
                    showHideShop.onColission = true;
                    this.enabled = false;
                    showHideShop.Start();
                    showHideShop.showHideInventory.shopOpen = true;
                    showHideShop.playerInventory.GetComponent<Canvas>().enabled = false;
                    showHideShop.showHideInventory.stats.SetActive(false);
                    showHideShop.showHideInventory.shown = false;
                }
            }
            else
            {
                dialogueElements.Clear();
                dialogueElements.Add("Tendero: Encuentra mi pelo");
                dialogueElements.Add("Tendero: Hasta entonces no abriré la tienda");
            }
            
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                if (slots[i].transform.GetChild(0).transform.name == "Peluquin (UI)")
                {
                    item = slots[i].transform.GetChild(0).transform;
                    hasHair = true;
                }
            }
        }
    }
}
