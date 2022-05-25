using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDungeonWithKey : MonoBehaviour
{
    private DungeonUnlocker dungeonUnlocker;
    private ShowHideInventory showHideInventory;

    private void Start() {
        dungeonUnlocker = GameObject.Find("Fountain").GetComponentInChildren<DungeonUnlocker>();
        showHideInventory = GameObject.Find("InventoryManager").GetComponentInChildren<ShowHideInventory>();
    }

    public void UseKey()
    {
        dungeonUnlocker.keyUsed = true;
        showHideInventory.closeOpenPanels();
    }
}
