using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potions : MonoBehaviour
{
    public float healthToGiver = 0;
    public GameObject itemToAdd;
    public int amountToAdd;
    Inventory inventory;
    InventorySingleton inventorySingleton;


    void Start()
    {
        inventorySingleton = InventorySingleton.instance;
        inventory = inventorySingleton.GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventory.CheckSlotsAvailability(itemToAdd, itemToAdd.name, amountToAdd);

            Destroy(gameObject);
        }
    }
}
