using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideInventory : MonoBehaviour
{
    public GameObject inventory;
    public GameObject stats;
    public bool shown;

    private void Start()
    {
        shown = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventory.SetActive(!shown);
            stats.SetActive(!shown);
            shown = !shown;
        }
    }
}
