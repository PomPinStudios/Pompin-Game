using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] Canvas npcShop;
    // Start is called before the first frame update
    void Start()
    {
        npcShop.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        npcShop.gameObject.SetActive(false);
    }
    void OnTriggerStay2D(Collider2D other) {
        if (Input.GetButton("Interactive"))
        {

            npcShop.gameObject.SetActive(true);

        }
    }
}
