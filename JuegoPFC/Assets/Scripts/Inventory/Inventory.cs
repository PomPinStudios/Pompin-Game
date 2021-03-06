using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    public GameObject[] slots;
    public GameObject[] backPack;
    private bool isInstantiated;
    TextMeshProUGUI text;
    public ItemList itemList;
    public Dictionary<string, int> inventoryItems = new Dictionary<string, int>();

    GameData gameData;
    public bool cargando = false;

     public AudioSource clip;

    private void Start()
    {
        if (itemList != null)
        {
            DataToInventory();
        }

        gameData = GameData.instance;
    }

    public void CheckSlotsAvailability(GameObject itemToAdd, string itemName, int itemAmount)
    {
        isInstantiated = false;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount > 0)
            {
                slots[i].GetComponent<SlotsScript>().isUsed = true;
            }
            else if (!isInstantiated && slots[i].GetComponent<SlotsScript>().isUsed == false)
            {
                if (!inventoryItems.ContainsKey(itemName))
                {
                    GameObject item = Instantiate(itemToAdd, slots[i].transform.position, Quaternion.identity);
                    item.transform.SetParent(slots[i].transform, false);
                    item.transform.localPosition = new Vector3(0, 0, 0);
                    item.name = item.name.Replace("(Clone)", "");
                    isInstantiated = true;
                    slots[i].GetComponent<SlotsScript>().isUsed = true;
                    inventoryItems.Add(itemName, itemAmount);
                    text = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                    text.text = itemAmount.ToString();
                    clip.Play();
                    break;
                }
                else
                {
                    for (int j = 0; j < slots.Length; j++)
                    {
                        // if (slots[j].transform.childCount != 0)
                        // {
                        if (slots[j].transform.GetChild(0).gameObject.name == itemName)
                        {
                            if(cargando){
                                inventoryItems[itemName] = itemAmount;
                                text = slots[j].GetComponentInChildren<TextMeshProUGUI>();
                                text.text = inventoryItems[itemName].ToString();
                                break;
                            }else{
                                inventoryItems[itemName] += itemAmount;
                                text = slots[j].GetComponentInChildren<TextMeshProUGUI>();
                                text.text = inventoryItems[itemName].ToString();
                                clip.Play();
                                break;
                            }
                        }
                        // }
                    }
                    break;
                }
            }
        }

    }

    public void UseInventoryItems(string itemName, int itemCount = 0)
    {
        if (itemCount == 0)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].transform.childCount != 0)
                {
                    if (slots[i].transform.GetChild(0).gameObject.name == itemName)
                    {
                        inventoryItems[itemName]--;
                        text = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                        text.text = inventoryItems[itemName].ToString();

                        if (inventoryItems[itemName] <= 0)
                        {
                            Destroy(slots[i].transform.GetChild(0).gameObject);
                            slots[i].GetComponent<SlotsScript>().isUsed = false;
                            inventoryItems.Remove(itemName);
                            ReorganizeInventory();
                        }

                        break;
                    }
                }
            }
        }
        else
        {
            for (int j = 0; j < itemCount; j++)
            {
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].transform.GetChild(0).gameObject.name == itemName)
                    {
                        inventoryItems[itemName]--;
                        text = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                        text.text = inventoryItems[itemName].ToString();

                        if (inventoryItems[itemName] <= 0)
                        {
                            Destroy(slots[i].transform.GetChild(0).gameObject);
                            slots[i].GetComponent<SlotsScript>().isUsed = false;
                            inventoryItems.Remove(itemName);
                            ReorganizeInventory();
                        }

                        break;
                    }
                }
            }
        }
    }

    private void ReorganizeInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].GetComponent<SlotsScript>().isUsed)
            {
                for (int j = i + 1; j < slots.Length; j++)
                {
                    if (slots[j].GetComponent<SlotsScript>().isUsed)
                    {
                        // if (slots[j].transform.childCount != 0)
                        // {
                        Transform itemToMove = slots[j].transform.GetChild(0).transform;
                        itemToMove.transform.SetParent(slots[i].transform, false);
                        itemToMove.transform.localPosition = new Vector3(0, 0, 0);
                        slots[i].GetComponent<SlotsScript>().isUsed = true;
                        slots[j].GetComponent<SlotsScript>().isUsed = false;
                        break;
                        // }
                    }
                }
            }
        }
    }

    public void InventoryToData()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<SlotsScript>().isUsed)
            {
                if (slots[i].transform.childCount != 0)
                {
                    if (!gameData.saveData.goToAddId.Contains(slots[i].GetComponentInChildren<ItemsUse>().ID))
                    {
                        gameData.saveData.goToAddId.Add(slots[i].GetComponentInChildren<ItemsUse>().ID);
                        gameData.saveData.inventoryItemsName.Add(slots[i].GetComponentInChildren<ItemsUse>().name);
                        gameData.saveData.inventoryItemsAmount.Add(inventoryItems[slots[i].GetComponentInChildren<ItemsUse>().name]);
                    }
                }

            }
        }
    }

    public void DataToInventory()
    {
        cargando = true;

        for (int i = 0; i < GameData.instance.saveData.goToAddId.Count; i++)
        {
            for (int j = 0; j < itemList.items.Count; j++)
            {
                if (itemList.items[j].ID == GameData.instance.saveData.goToAddId[i])
                {
                    CheckSlotsAvailability(itemList.items[j].gameObject, GameData.instance.saveData.inventoryItemsName[i],
                        GameData.instance.saveData.inventoryItemsAmount[i]);
                }
            }
        }


        foreach(var slot in slots)
        {
            if(slot.transform.childCount > 0)
            {
                if(!GameData.instance.saveData.goToAddId.Contains(slot.GetComponentInChildren<ItemsUse>().ID))
                {
                    var itemName = slot.transform.GetChild(0).gameObject.name;
                    Destroy(slot.transform.GetChild(0).gameObject);
                    inventoryItems.Remove(itemName);
                    slot.GetComponent<SlotsScript>().isUsed = false;
                }
            }
        }
    }

}
