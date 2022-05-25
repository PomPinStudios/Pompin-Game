using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDungeonWithKey : MonoBehaviour
{
    private DungeonUnlocker dungeonUnlocker;
    private ShowHideInventory showHideInventory;
    Inventory inventory;
    InventorySingleton inventorySingleton;

    private void Start() {
        dungeonUnlocker = GameObject.Find("Fountain").GetComponentInChildren<DungeonUnlocker>();
        showHideInventory = GameObject.Find("InventoryManager").GetComponentInChildren<ShowHideInventory>();
        inventorySingleton = InventorySingleton.instance;
        inventory = inventorySingleton.GetComponent<Inventory>();
    }

    public void UseKey()
    {
        if(dungeonUnlocker.onCollision)
        {
            inventory.UseInventoryItems(gameObject.name, 0);
            MostrarInfoObjecto mostrarInfoObjecto = GetComponent<MostrarInfoObjecto>();
            mostrarInfoObjecto.panel.GetComponent<Image>().enabled = false;
            mostrarInfoObjecto.TextTipo.enabled = false;
            mostrarInfoObjecto.TextNombre.enabled = false;
            mostrarInfoObjecto.TextDescripcion.enabled = false;
            dungeonUnlocker.keyUsed = true;
            showHideInventory.closeOpenPanels();
        }
    }
}
