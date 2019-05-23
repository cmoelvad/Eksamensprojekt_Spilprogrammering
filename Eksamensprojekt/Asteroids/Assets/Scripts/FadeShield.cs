using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeShield : MonoBehaviour
{
    private int shieldHealth;
    private float alphaDecrease;
    private SpriteRenderer sprite;
    private GameController gc;
    private bool shieldBlock = true;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        sprite = GetComponent<SpriteRenderer>();
        shieldHealth = gc.getShield();
        alphaDecrease = sprite.color.a/shieldHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        IAsteroid asteroid = collision.GetComponent<IAsteroid>();
        if(asteroid != null && shieldBlock == true)
        {
           
            updateShieldHealth(-gc.asteroidShieldDamage);
            gc.score += gc.asteroidPoints;
            asteroid.Split();
        }
        else if(collision.gameObject.tag == "EnemyAmmo" && shieldBlock == true)
        {
            updateShieldHealth(-gc.asteroidShieldDamage);
            Destroy(collision.gameObject);
        }
    }

    public void updateShieldHealth(int shieldAmount)
    {
        shieldHealth += shieldAmount;
        if (shieldHealth <= 0)
        {
            shieldHealth = 0;
            shieldBlock = false;
        }
        else
        {
            shieldBlock = true;
        }
        Color tmpColor = sprite.color;
        tmpColor.a += alphaDecrease * shieldAmount;
        sprite.color = tmpColor;
        gc.shield = shieldHealth;
    }
}
