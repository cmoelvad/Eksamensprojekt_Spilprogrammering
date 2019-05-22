using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour, IAsteroid
{
    public int size = 3;

    public Rigidbody2D[] minorAsteroids = new Rigidbody2D[3];

    private Rigidbody2D rb;
    private GameController gc;
    private int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        rb = GetComponent<Rigidbody2D>();
        pointValue = gc.asteroidPoints;
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
        else if(collision.gameObject.tag == "Bullet" || collision.gameObject.name == "Spaceship")
        {
            gc.increaseScore(pointValue);
            Split();
        }
    }

    public void Split()
    {
        if (size > 1)
        {
            foreach (Rigidbody2D minorAsteroid in minorAsteroids)
            {
                transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
                Vector2 direction = transform.TransformDirection(Vector2.up);
                Rigidbody2D asteroidInstance = Instantiate(minorAsteroid, transform.position, transform.rotation);
                Vector2 force = direction * rb.velocity;
                asteroidInstance.AddForce(force, ForceMode2D.Impulse);
            }
        }

        Destroy(gameObject);
    }
}
