using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeShield : MonoBehaviour
{
    private int shieldHealth;
    private float alphaDecrease;
    private SpriteRenderer sprite;
    private GameController gc;
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
        if(asteroid != null)
        {
            Color tmpColor = sprite.color;
            tmpColor.a -= alphaDecrease * gc.asteroidShieldDamage;
            sprite.color = tmpColor;
            shieldHealth -= gc.asteroidShieldDamage;
            gc.shield = shieldHealth;
            if(shieldHealth <= 0)
            {
                gameObject.SetActive(false);
            }

            asteroid.Split();
        }
    }
}
