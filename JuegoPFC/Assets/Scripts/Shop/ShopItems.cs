using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItems : MonoBehaviour
{
    private string itemName;
    public int itemSellPrice;
    public int itemBuyPrice;
    public GameObject itemToAdd;
    public int amountToAdd;
    Inventory inventory;
    InventorySingleton inventorySingleton;

    public TextMeshProUGUI buyPriceText;

    public ShopNPC shopNPC;
    private PlayerStats playerStats;


    void Start()
    {
        inventorySingleton = InventorySingleton.instance;
        inventory = inventorySingleton.GetComponent<Inventory>();
        itemName = itemToAdd.name;
        buyPriceText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        playerStats = GameManager.instance.player.gameObject.GetComponent<PlayerStats>(); 
        shopNPC = transform.root.GetComponent<ShopNPC>();
    }

    private void Update() {
        UpdateText();
    }

    public void BuyItem()
    {
        if(!shopNPC.sellItems)
        {
            if(itemBuyPrice <= playerStats.money)
            {
                playerStats.UpdateMoney(-itemBuyPrice);
                inventory.CheckSlotsAvailability(itemToAdd, itemToAdd.name, amountToAdd);
            }
        }
        else if(inventory.inventoryItems.ContainsKey(itemToAdd.name))
        {
            inventory.UseInventoryItems(itemToAdd.name);
            playerStats.UpdateMoney(itemSellPrice);
        }
    }

    public void UpdateText()
    {
        if(!shopNPC.sellItems)
        {
            buyPriceText.text = "$ " + itemBuyPrice.ToString();
        }
        else
        {
            buyPriceText.text = "$ " + itemSellPrice.ToString();
        }
    }
}
