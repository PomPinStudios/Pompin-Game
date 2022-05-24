using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnController : MonoBehaviour
{
    private QuestsController questsController;

    void Start()
    {
        questsController = GameObject.Find("GameManager").GetComponent<QuestsController>();
        switch (gameObject.name)
        {
            case "Wood":
                if(questsController.wood1)
                {
                    Destroy(gameObject);
                }
                break;
            case "Wood (1)":
                if(questsController.wood2)
                {
                    Destroy(gameObject);
                }
                break;
            case "Wood (2)":
                if(questsController.wood3)
                {
                    Destroy(gameObject);
                }
                break;
            case "Peluquin":
                if(questsController.peluquinRecogido)
                {
                    Destroy(gameObject);
                }
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            switch (gameObject.name)
            {
                case "Wood":
                    Debug.Log("1");
                    questsController.wood1 = true;
                    break;
                case "Wood (1)":
                    Debug.Log("2");
                    questsController.wood2 = true;
                    break;
                case "Wood (2)":
                    Debug.Log("3");
                    questsController.wood3 = true;
                    break;
                case "Peluquin":
                    Debug.Log("Peluquin");
                    questsController.peluquinRecogido = true;
                    break;

            }
        }
    }
}
