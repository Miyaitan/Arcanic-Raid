using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public float stamina;
    public float health;
    public float damage;
    public float healthPercent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStats>() != null)
        {
            PlayerStats player = collision.gameObject.GetComponent<PlayerStats>();
            Projectile bullet = gameObject.GetComponent<Projectile>();
            player.health += health;
            player.stamina += stamina;
            //bullet.damage += damage;

            float hpregen;
            hpregen = healthPercent * player.maxHealth / 100;
            player.health += hpregen;
            Destroy(gameObject);
        }
    }
}
