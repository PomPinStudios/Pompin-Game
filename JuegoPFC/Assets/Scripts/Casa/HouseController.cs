using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HouseController : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite repairHouse;
    public GameObject transitionHouse;
    private Inventory inventory;
    private InventorySingleton inventorySingleton;
    private GameObject[] slots;

    private Dialogue dialogue;
    private List<string> dialogueElements;

    private bool primeraInteraccion;
    private bool inColision;

    public Quest questRepairHouse;
    private QuestManager questManager; 
    private bool addQuest = true;

    private SceneChangeController sceneChangeController;

    void Start()
    {
        sceneChangeController = GameObject.Find("GameManager").GetComponent<SceneChangeController>();
        if(sceneChangeController.casaRepair)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = repairHouse;
            Destroy(gameObject.transform.Find("Nota").gameObject);
            gameObject.transform.Find("Door").gameObject.SetActive(true);
            transitionHouse.SetActive(true);
        }
        questManager = GameObject.Find("Quests").GetComponent<QuestManager>();
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
        if (dialogue.firstInteraction)
        {
            dialogueElements.Clear();
            dialogueElements.Add(woodCount + "/3");
        }

        if(inColision && dialogue.firstInteraction) { RepairHouse(); }

        if(addQuest && dialogue.firstInteraction){
            questManager.addQuest(questRepairHouse);
            addQuest = false;
        }
    }
    private int woodCount;
    private Transform item;

    private void OnTriggerEnter2D(Collider2D other) {
        inColision = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        inColision = false;
    }
    void RepairHouse()
    {
        if (Input.GetButtonDown("Interactive"))
        {
            if (woodCount >= 3)
            {
                sceneChangeController.casaRepair = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = repairHouse;
                Destroy(gameObject.transform.Find("Nota").gameObject);
                inventory.UseInventoryItems(item.name, 3);
                gameObject.transform.Find("Door").gameObject.SetActive(true);
                transitionHouse.SetActive(true);

                EventManager.Instance.QueueEvent(new BuildingGameEvent("Casa"));
            }
            
        }
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount != 0)
            {
                if (slots[i].transform.GetChild(0).transform.name == "Wood (USE)")
                {
                    item = slots[i].transform.GetChild(0).transform;
                    TextMeshProUGUI text = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                    woodCount = int.Parse(text.text);
                }
            }
        }
    }
}
