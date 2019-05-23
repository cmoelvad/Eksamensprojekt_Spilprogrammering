using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimeAndHit : MonoBehaviour
{
    public float lifeTime = 5.0f;
    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("removeObject", lifeTime);
        gc = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IAsteroid asteroid = collision.GetComponent<IAsteroid>();
        IEnemy enemy = collision.GetComponent<IEnemy>();
        if(asteroid != null)
        {
            asteroid.Split();
            gc.score += gc.asteroidPoints;
            removeObject();
        }
        else if(enemy != null)
        {
            enemy.takeDamage(1);
            gc.money += enemy.getMoneyWorth();
            removeObject();
        }

    }

    private void removeObject()
    {
        Destroy(gameObject);
    }
}
