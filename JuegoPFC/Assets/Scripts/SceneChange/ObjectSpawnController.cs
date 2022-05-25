using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnController : MonoBehaviour
{
    private SceneChangeController sceneChangeController;

    void Start()
    {
        sceneChangeController = GameObject.Find("GameManager").GetComponent<SceneChangeController>();
        switch (gameObject.name)
        {
            case "Wood":
                if(sceneChangeController.wood1)
                {
                    Destroy(gameObject);
                }
                break;
            case "Wood (1)":
                if(sceneChangeController.wood2)
                {
                    Destroy(gameObject);
                }
                break;
            case "Wood (2)":
                if(sceneChangeController.wood3)
                {
                    Destroy(gameObject);
                }
                break;
            case "Peluquin":
                if(sceneChangeController.peluquinRecogido)
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
                    sceneChangeController.wood1 = true;
                    break;
                case "Wood (1)":
                    Debug.Log("2");
                    sceneChangeController.wood2 = true;
                    break;
                case "Wood (2)":
                    Debug.Log("3");
                    sceneChangeController.wood3 = true;
                    break;
                case "Peluquin":
                    Debug.Log("Peluquin");
                    sceneChangeController.peluquinRecogido = true;
                    break;

            }
        }
    }
}
