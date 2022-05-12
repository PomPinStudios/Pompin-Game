using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsUse : MonoBehaviour
{
    public int ID;
    public float healthToGive;
    public float manaToGive;
    PlayerStats playerStats;
    PlayerSingleton playerSingleton;

    void Start()
    {
        playerSingleton = PlayerSingleton.instance;
        playerStats = playerSingleton.GetComponent<PlayerStats>();
    }

    public void UseButton()
    {
        if (gameObject.name == "Potion (USE)")
        {
            playerStats.UpdateHealth(healthToGive);
        }
    }

}
