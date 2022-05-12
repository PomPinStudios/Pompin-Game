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

    private void Start() {
        if(itemList )
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
                    break;
                }
                else
                {
                    for (int j = 0; j < slots.Length; j++)
                    {
                        if (slots[j].transform.GetChild(0).gameObject.name == itemName)
                        {
                            inventoryItems[itemName] += itemAmount;
                            text = slots[j].GetComponentInChildren<TextMeshProUGUI>();
                            text.text = inventoryItems[itemName].ToString();
                            break;
                        }
                    }
                    break;
                }
            }
        }

    }

    public void UseInventoryItems(string itemName, int itemCount)
    {
        if(itemCount == 0)
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
        else
        {
            for(int j = 0; j < itemCount; j++)
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
                        Transform itemToMove = slots[j].transform.GetChild(0).transform;
                        itemToMove.transform.SetParent(slots[i].transform, false);
                        itemToMove.transform.localPosition = new Vector3(0, 0, 0);
                        slots[i].GetComponent<SlotsScript>().isUsed = true;
                        slots[j].GetComponent<SlotsScript>().isUsed = false;
                        break;
                    }
                }
            }
        }
    }
}
