using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpriteChanger : MonoBehaviour
{
    public bool onCollision;
    public SpriteRenderer sprite;
    public Sprite spriteOpen;
    public Sprite spriteClose;
    private bool addQuest = true;
    private Dialogue dialogue;
    private QuestManager questManager;
    public Quest questEspada;



    void Start()
    {
        questManager = GameObject.Find("Quests").GetComponent<QuestManager>();
        dialogue = gameObject.GetComponent<Dialogue>();
    }

    void Update()
    {
        if (onCollision)
        {
            if (Input.GetButtonDown("Interactive"))
            {
                sprite.sprite = spriteOpen;
            }
        }
        if (!onCollision)
        {
            sprite.sprite = spriteClose;
        }

        if (addQuest && dialogue.firstInteraction)
        {
            questManager.addQuest(questEspada);
            addQuest = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        onCollision = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onCollision = false;
    }


}
