using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int lifeTime = 5;

    private GameController gc;
    void Start()
    {
        Invoke("removeObject", lifeTime);
        gc = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gc.health -= 1;
            removeObject();
        }
    }

    private void removeObject()
    {
        Destroy(gameObject);
    }
}
