using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Quest mazmorraQuest;
    private QuestManager questManager;

    void Start()
    {
        
        questManager = GameObject.Find("Quests").GetComponent<QuestManager>();
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
        if(itemName == "Key (USE)"){

            Debug.Log(shopNPC.itemHolder.transform.childCount);
            for(int i = 0; i<shopNPC.itemHolder.transform.childCount; i++)
            {
                Transform t = shopNPC.itemHolder.transform.GetChild(i);
                Debug.Log(t.gameObject.name);
                if(t.childCount > 0)
                {
                    if(t.GetChild(0).name == "DungeonKey (Store)")
                    {
                        MostrarInfoObjecto mostrarInfoObjecto = GetComponent<MostrarInfoObjecto>();
                        mostrarInfoObjecto.panel.GetComponent<Image>().enabled = false;
                        mostrarInfoObjecto.TextTipo.enabled = false;
                        mostrarInfoObjecto.TextNombre.enabled = false;
                        mostrarInfoObjecto.TextDescripcion.enabled = false;
                        questManager.addQuest(mazmorraQuest);
                        Destroy(t.GetChild(0).gameObject);
                    }
                }
            }

        }

        if(!shopNPC.sellItems)
        {
            if(itemBuyPrice <= playerStats.money)
            {
                playerStats.UpdateMoney(-itemBuyPrice);
                inventory.cargando = false;
                inventory.CheckSlotsAvailability(itemToAdd, itemToAdd.name, amountToAdd);
            }
        }
        else if(inventory.inventoryItems.ContainsKey(itemToAdd.name))
        {
            inventory.UseInventoryItems(itemToAdd.name, 0);
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
