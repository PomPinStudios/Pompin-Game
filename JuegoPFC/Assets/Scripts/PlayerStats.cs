using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Space]
    public float health = 0f;
    public float maxHealth;
    public Slider healthSlider;
    public Text healthText;

    [Space]
    public int damage;

    [Space]
    public float money;
    public Text moneyText;

    [Space]
    public float currExp;
    public float maxExp;
    public Slider expSlider;

    [Space]
    public int level;
    public int currentStatPoints;

    [Space]
    public int armor;

    private void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthText.text = health.ToString() + " / " + maxHealth.ToString();

        expSlider.value = currExp;
        expSlider.maxValue = maxExp;

        moneyText.text = money.ToString();
    }

    public void UpdateHealth(float mod)
    {
        health += mod;
        healthText.text = health.ToString() + " / " + maxHealth.ToString();

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0f)
        {
            health = 0f;
            healthSlider.value = health;
            healthText.text = "0 / 100";
            Destroy(gameObject);
            Debug.Log("Tas muerto");
        }
    }

    public void UpdateMaxHealth(float mod)
    {
        maxHealth += mod;
        healthSlider.maxValue = maxHealth;
        healthText.text = health.ToString() + " / " + maxHealth.ToString();
    }

    public void UpdateExp(float exp)
    {
        currExp += exp;

        if (currExp >= maxExp)
        {
            level += 1;
            currExp = 0;

            currentStatPoints += 3;

            UpdateMaxExp();

        }

        expSlider.value = currExp;
    }

    public void UpdateMoney(float dinero)
    {
        money += dinero;
        if (money >= 0)
        {
            moneyText.text = money.ToString();
        }

    }


    private void UpdateMaxExp()
    {
        float nextCap = maxExp + (maxExp * 0.45f);
        maxExp = nextCap;
        expSlider.maxValue = maxExp;
    }

    void OnGUI()
    {
        float t = Time.deltaTime / 0.5f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
    }
}

