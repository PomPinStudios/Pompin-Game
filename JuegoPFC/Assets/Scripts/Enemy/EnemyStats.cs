using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Health")]
    private float health;
    [SerializeField] private float maxHealth;

    void Start()
    {
        health = maxHealth;
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Health" + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
