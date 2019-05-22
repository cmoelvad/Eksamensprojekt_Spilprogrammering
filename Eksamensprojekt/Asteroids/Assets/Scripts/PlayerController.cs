using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public float currentVelocity;
    [Range(1,20)]
    public float maxSpeed = 8.0f;
    [Range(1,20)]
    public float acceleration = 2.0f;
    [Range(1, 5f)]
    public float rotation = 3.0f;

    public Rigidbody2D[] weapons = new Rigidbody2D[3];
    public Transform bulletEntry;
    public float bulletSpeed = 20.0f;

    private Rigidbody2D rb;
    private GameController gc;
    
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody2D>();
        gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        shoot();
    }

    private void FixedUpdate()
    {
        float h = -Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 speed = transform.up * (v * acceleration);
        rb.AddForce(speed);

        rb.rotation += h * rotation;

        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        currentVelocity = rb.velocity.magnitude;
    }

    private void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 direction = bulletEntry.TransformDirection(Vector2.up);

            Rigidbody2D shotInstance = Instantiate(weapons[0], bulletEntry.transform.position, bulletEntry.transform.rotation);

            Vector2 force = direction * bulletSpeed;
            shotInstance.AddForce(force, ForceMode2D.Impulse);
        }

        else if (Input.GetButtonDown("Fire2"))
        {
            Vector2 direction = bulletEntry.TransformDirection(Vector2.up);

            Rigidbody2D shotInstance = Instantiate(weapons[1], bulletEntry.transform.position, bulletEntry.transform.rotation);

            Vector2 force = direction * bulletSpeed;
            shotInstance.AddForce(force, ForceMode2D.Impulse);
        }

        else if (Input.GetButtonDown("Fire3"))
        {
            Vector2 direction = bulletEntry.TransformDirection(Vector2.up);

            Rigidbody2D shotInstance = Instantiate(weapons[2], bulletEntry.transform.position, bulletEntry.transform.rotation);

            Vector2 force = direction * bulletSpeed;
            shotInstance.AddForce(force, ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            gc.changeHealth(-1);
        }
    }
}
