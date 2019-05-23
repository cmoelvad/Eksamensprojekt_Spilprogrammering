using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour, IWhitelist
{   
    public float currentVelocity;
    [Range(1,20)]
    public float maxSpeed = 8.0f;
    [Range(1,20)]
    public float acceleration = 2.0f;
    [Range(1, 5f)]
    public float rotation = 3.0f;

    public Rigidbody2D weapon;
    public Transform[] bulletEntrys = new Transform[3];
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
        if (Input.GetButtonDown("Brake"))
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        currentVelocity = rb.velocity.magnitude;
    }

    private void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 direction = bulletEntrys[0].TransformDirection(Vector2.up);

            Rigidbody2D shotInstance = Instantiate(weapon, bulletEntrys[0].transform.position, bulletEntrys[0].transform.rotation);

            Vector2 force = direction * bulletSpeed;
            shotInstance.AddForce(force, ForceMode2D.Impulse);
        }

        else if (Input.GetButtonDown("Fire2") && gc.specialAmmo > 0)
        {
            foreach(Transform bulletEntry in bulletEntrys)
            {
                Vector2 direction = bulletEntry.TransformDirection(Vector2.up);

                Rigidbody2D shotInstance = Instantiate(weapon, bulletEntry.transform.position, bulletEntry.transform.rotation);

                Vector2 force = direction * bulletSpeed;
                shotInstance.AddForce(force, ForceMode2D.Impulse);
            }
            gc.specialAmmo--;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyAmmo")
        {
            gc.changeHealth(-1);
        }
    }
}
