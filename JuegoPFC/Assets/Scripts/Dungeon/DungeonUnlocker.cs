using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonUnlocker : MonoBehaviour
{
    [HideInInspector]
    public bool onCollision;
    
    private bool moveFountain;
    GameObject fountain;
    private SceneChangeController sceneChangeController;
    [HideInInspector]
    public bool keyUsed;
    public AudioSource clip;
    public PolygonCollider2D collider; 

    void Start()
    {
        sceneChangeController = GameObject.Find("GameManager").GetComponent<SceneChangeController>();
        fountain = GameObject.Find("Fountain");
        if(sceneChangeController.fountainMove) {
            fountain.transform.position = new Vector2(-30, fountain.transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(onCollision && keyUsed){
            collider.enabled = false;
            clip.Play();
            sceneChangeController.fountainMove = true;
            moveFountain = true;
        }

        if(moveFountain)
        {
            if(fountain.transform.position.x >= -30 ){
                EventManager.Instance.QueueEvent(new PlacesGameEvent("Mazmorra"));
                moveFountain = false;
            }
            fountain.transform.Translate(0.8f * Time.deltaTime, 0, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other) {
        onCollision = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onCollision = false;
    }
}
