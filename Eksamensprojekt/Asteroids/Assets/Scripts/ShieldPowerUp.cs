using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour, IPowerUp
{

    private GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        Invoke("destroyPowerUp", gc.powerUpDuration);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FadeShield entity = collision.GetComponentInChildren<FadeShield>();
        if (entity != null)
        {
            entity.updateShieldHealth(gc.asteroidShieldDamage);
            destroyPowerUp();
        }
    }

    public void destroyPowerUp()
    {
        Destroy(gameObject);
    }
}
