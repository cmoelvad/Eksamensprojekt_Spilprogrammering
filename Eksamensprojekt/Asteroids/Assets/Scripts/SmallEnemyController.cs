using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyController : MonoBehaviour, IEnemy
{
    public int health = 2;
    public Transform gunTower;
    public Rigidbody2D bullet;
    public float bulletSpeed = 5f;
    public Transform bullethole;
    public float timeBetweenShots = 1f;
    public int moneyWorth = 3;

    private Transform target;
    private float timeSinceLastShot;
    private bool allowedToFire;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;
        allowedToFire = GetComponentInChildren<AllowedToFire>().allowedToFire;
    }

    // Update is called once per frame
    void Update()
    {
        allowedToFire = GetComponentInChildren<AllowedToFire>().allowedToFire;
        float rotation = Mathf.Atan2(target.position.y-transform.position.y, target.position.x - transform.position.x) *Mathf.Rad2Deg;
        gunTower.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation -90f);
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

    public int getMoneyWorth()
    {
        return moneyWorth;
    }

}
