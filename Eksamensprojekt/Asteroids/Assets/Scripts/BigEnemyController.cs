using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyController : MonoBehaviour, IEnemy
{
    public int health = 4;
    public Rigidbody2D bullet;
    public float bulletSpeed = 5f;
    public Transform bullethole;
    public float timeBetweenShots = 2f;
    public int moneyWorth = 5;

    private float timeSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeSinceLastShot > timeBetweenShots)
        {
            shoot();
            timeSinceLastShot = Time.time;
        }
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
        bullethole.Rotate(0, 0, Random.value * 360);

        Vector2 direction = bullethole.TransformDirection(Vector2.up);
        Rigidbody2D shotinstance = Instantiate(bullet, bullethole.transform.position, bullethole.transform.rotation);

        Vector2 force = direction * bulletSpeed;

        shotinstance.AddForce(force, ForceMode2D.Impulse);
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public int getMoneyWorth()
    {
        return moneyWorth;
    }
}
