using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour, IPowerUp
{

    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        Invoke("destroyPowerUp", gc.powerUpDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController entity = collision.GetComponent<PlayerController>();

        if (entity != null)
        {
            gc.specialAmmo++;
            destroyPowerUp();
        }
    }

    public void destroyPowerUp()
    {
        Destroy(gameObject);
    }
}
