using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
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
            inventory.cargando = false;
            inventory.CheckSlotsAvailability(itemToAdd, itemToAdd.name, amountToAdd);

            Destroy(gameObject);
        }
    }
}
