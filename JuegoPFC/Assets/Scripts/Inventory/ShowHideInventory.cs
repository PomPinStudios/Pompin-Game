using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideInventory : MonoBehaviour
{
    public GameObject inventory;
    public bool shown;

    private void Start()
    {
        shown = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!shown);
            shown = !shown;
        }
    }
}
