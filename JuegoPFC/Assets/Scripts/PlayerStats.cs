using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthSlider;
    public Text healthText;
    public float money;
    public Text moneyText; 

    private void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthText.text = health.ToString() + " / 100";
        moneyText.text = money.ToString();
    }


    public void UpdateHealth(float mod)
    {
        health += mod;
        healthText.text = health.ToString() + " / 100";

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

    public void UpdateMoney(float dinero)
    {
        money += dinero;
        if(money >= 0){
            moneyText.text = money.ToString();
        }
        
    }

    void OnGUI()
    {
        float t = Time.deltaTime / 0.5f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
    }
}

