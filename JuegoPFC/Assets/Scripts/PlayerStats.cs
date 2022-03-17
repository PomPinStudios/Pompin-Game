using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private float health = 0f;
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Text healthText;

    private void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthText.text = health.ToString() + " / 100";
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

    void OnGUI()
    {
        float t = Time.deltaTime / 0.5f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
    }
}

