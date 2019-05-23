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
        IAsteroid entity = collision.GetComponent<IAsteroid>();
        if(entity != null)
        {
            entity.Split();
            gc.score += gc.asteroidPoints;
            removeObject();
        }
    }

    private void removeObject()
    {
        Destroy(gameObject);
    }
}
