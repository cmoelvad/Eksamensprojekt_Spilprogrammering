using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyController : MonoBehaviour, IEnemy
{
    public int health = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "AsteroidKiller")
        {
            Destroy(gameObject);
        }
    }

    public void shoot()
    {
        throw new System.NotImplementedException();
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
