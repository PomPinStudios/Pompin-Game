using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];
    public float coins;
    public Text CoinsText;
    void Start()
    {
        CoinsText.text = "x " + coins.ToString();

        shopItems[1,1] = 1;
        shopItems[1,2] = 2;
        shopItems[1,3] = 3;
        shopItems[1,4] = 4;

        shopItems[2,1] = 10;
        shopItems[2,2] = 20;
        shopItems[2,3] = 30;
        shopItems[2,4] = 40;

        shopItems[3,1] = 0;
        shopItems[3,2] = 0;
        shopItems[3,3] = 0;
        shopItems[3,4] = 0;
    }

    public void Buy()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if(coins >= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID])
        {
            coins -= shopItems[2, buttonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, buttonRef.GetComponent<ButtonInfo>().ItemID]++;
            CoinsText.text = "x " + coins.ToString();
            buttonRef.GetComponent<ButtonInfo>().QuantityText.text = shopItems[3, buttonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }
}
