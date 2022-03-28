using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Health")]
    private float health;
    [SerializeField] private float maxHealth;
    public EnemyHealthbar healthBar;
    public GameObject dropItem;
    public int dropCount = 5;
    //Expansion de los objetos
    public float spread = 1f;


    void Start()
    {
        health = maxHealth;
        healthBar.SetHealth(health, maxHealth);
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health, maxHealth);

        if (health <= 0)
        {
            while(dropCount > 0)
            {
                dropCount -= 1;
                Vector3 position = transform.position;
                position.x += spread * UnityEngine.Random.value - spread / 2;
                position.y += spread * UnityEngine.Random.value - spread / 2;
                GameObject drop = Instantiate(dropItem);
                drop.transform.position = position;
            }
            Destroy(gameObject);
        }
    }
}
