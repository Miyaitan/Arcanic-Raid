using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    
    public float health;
    public float maxHealth = 100;
    public float stamina;
    public float maxStamina = 100;

    public HealthBarScript healthBar;
    public HungerBarScript hungerBar;
    void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        stamina = maxStamina;
        hungerBar.SetMaxHunger(maxStamina);
    }

    // Update is called once per frame
    void Update()
    {

        stamina -= 2 * Time.deltaTime;
        hungerBar.SetHunger(stamina);
        if (health <= 0 || stamina <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
}
