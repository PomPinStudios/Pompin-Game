using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySingleton : MonoBehaviour
{
    public static InventorySingleton instance;

    private void Awake()
    {
        instance = this;
    }
}
