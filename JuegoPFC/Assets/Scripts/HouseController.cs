using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HouseController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite repairHouse;
    private Inventory inventory;
    private InventorySingleton inventorySingleton;
    private GameObject[] slots;

    private Dialogue  dialogue;
    private List<string> dialogueElements;

    private bool primeraInteraccion;

    void Start()
    {
        inventorySingleton = InventorySingleton.instance;
        inventory = inventorySingleton.GetComponent<Inventory>();
        slots = inventory.slots;
        dialogue = gameObject.GetComponentInChildren<Dialogue>();
        dialogueElements = dialogue.dialogueLines;
        dialogueElements.Add("Si reparas la casa es tuya");
        dialogueElements.Add("Necesitas 3 troncos");
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue.firstInteraction)
        {
            dialogueElements.Clear();
            dialogueElements.Add(woodCount +  "/3");
        }
    }
    private int woodCount;
    private Transform item;

    void OnTriggerStay2D(Collider2D other)
    {
        if(Input.GetButton("Interactive"))
        {
            if(woodCount == 3)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = repairHouse;
                Destroy(gameObject.transform.GetChild(0).gameObject);
                inventory.UseInventoryItems(item.name, woodCount);
            }
        }
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i].transform.childCount != 0)
            {
                if(slots[i].transform.GetChild(0).transform.name == "Wood (USE)")
                {
                    item = slots[i].transform.GetChild(0).transform;
                    TextMeshProUGUI text = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                    woodCount = int.Parse(text.text);
                }
            }
        }
    }
}
