using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideInventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject stats;
    public bool shown;

    [HideInInspector]
    public bool shopOpen = false;

    private void Start()
    {
        shown = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(!shopOpen){
                inventory.GetComponent<Canvas>().enabled = !inventory.GetComponent<Canvas>().enabled;
                stats.SetActive(!shown);
                shown = !shown;
            }
        }
    }
}
