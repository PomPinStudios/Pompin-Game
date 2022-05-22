using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsController : MonoBehaviour
{
    PlayerStats playerStats;
    PlayerSingleton playerSingleton;

    public TextMeshProUGUI level;
    public TextMeshProUGUI health;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI pointsRemaining;
    public TextMeshProUGUI money;

    void Start()
    {
        playerSingleton = PlayerSingleton.instance;
        playerStats = playerSingleton.GetComponent<PlayerStats>();

        // playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        DisplayStats();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayStats();
    }

    public void IncreaseStats(int statID)
    {
        if (statID == 1 && playerStats.currentStatPoints >= 1)
        {
            playerStats.UpdateMaxHealth(10);
            playerStats.currentStatPoints--;
        }
        if (statID == 2 && playerStats.currentStatPoints >= 1)
        {
            playerStats.damage += 2;
            playerStats.currentStatPoints--;
        }
        if (statID == 3 && playerStats.currentStatPoints >= 1)
        {
            playerStats.armor += 3;
            playerStats.currentStatPoints--;
        }
        DisplayStats();
    }

    public void DisplayStats()
    {
        level.text = "Nivel: " + playerStats.level;
        health.text = "Vida máxima: " + playerStats.maxHealth;
        damage.text = "Daño: " + playerStats.damage;
        armor.text = "Armadura: " + playerStats.armor;
        pointsRemaining.text = "Puntos disponibles: " + playerStats.currentStatPoints;
        money.text = "Dinero: " + playerStats.money;
    }
}
