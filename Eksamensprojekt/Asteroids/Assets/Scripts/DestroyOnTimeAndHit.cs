using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTimeAndHit : MonoBehaviour
{
    public float lifeTime = 5.0f;
    public Rigidbody2D shrunkBullet;
    [Range(1, 2)]
    public int bulletSize = 1;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("removeObject", lifeTime);
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(bulletSize == 2) 
        {
            Vector2 direction = transform.TransformDirection(Vector2.up);

            Rigidbody2D newBullet = Instantiate(shrunkBullet, transform.position, transform.rotation);

            Vector2 force = direction * rb.velocity;
            newBullet.AddForce(force, ForceMode2D.Impulse);
        }
        removeObject();
    }

    private void removeObject()
    {
        Destroy(gameObject);
    }
}
