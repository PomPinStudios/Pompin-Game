using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShopPanel : MonoBehaviour
{
    public Canvas shopCanvas;

    public void OpenPanel()
    {
        if(shopCanvas != null)
        {
            shopCanvas.gameObject.SetActive(false);
        }
    }
}
