using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButtons : MonoBehaviour
{
    Inventory inventory;
    InventorySingleton inventorySingleton;

    void Start()
    {
        inventorySingleton = InventorySingleton.instance;
        inventory = inventorySingleton.GetComponent<Inventory>();
    }

    public void UseItem()
    {
        inventory.UseInventoryItems(gameObject.name);
    }
}
