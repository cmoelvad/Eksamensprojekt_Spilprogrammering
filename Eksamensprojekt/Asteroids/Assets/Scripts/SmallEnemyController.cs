using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyController : MonoBehaviour, IEnemy
{
    public int health = 2;
    public Transform target;
    public Rigidbody2D bullet;
    public float bulletSpeed = 5f;
    public Transform bullethole;
    public float timeBetweenShots = 1f;
    private float timeSinceLastShot;
    private bool allowedToFire;
    // Start is called before the first frame update
    void Start()
    {
        allowedToFire = GetComponentInChildren<AllowedToFire>().allowedToFire;
    }

    // Update is called once per frame
    void Update()
    {
        allowedToFire = GetComponentInChildren<AllowedToFire>().allowedToFire;
        bullethole.LookAt(target);
        if(allowedToFire && Time.time-timeSinceLastShot > timeBetweenShots)
        {
            shoot();
            timeSinceLastShot = Time.time;
        }
    }

    public void shoot()
    {
        Vector2 direction = bullethole.TransformDirection(Vector2.up);
        Rigidbody2D shotInstance = Instantiate(bullet, bullethole.transform.position, bullethole.transform.rotation);
        Vector2 force = direction * bulletSpeed;
        print(direction);
        print(bulletSpeed);
        print(force);
        shotInstance.AddForce(force, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "AsteroidKiller")
        {
            Destroy(gameObject);
        }
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
