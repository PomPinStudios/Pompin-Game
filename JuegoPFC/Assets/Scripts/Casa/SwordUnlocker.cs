using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUnlocker : MonoBehaviour
{
    private Inventory inventory;
    private InventorySingleton inventorySingleton;
    private GameObject[] slots;
    private Transform item;
    private bool swordFound;
    // Start is called before the first frame update
    void Start()
    {
        inventorySingleton = InventorySingleton.instance;
        inventory = inventorySingleton.GetComponent<Inventory>();
        slots = inventory.slots;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EventManager.Instance.QueueEvent(new ObjectsGameEvent("Espada"));
        AttackUnlocker.isUnlocked = true;
    }

}
