using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowedToFire : MonoBehaviour, IWhitelist
{

    public bool allowedToFire = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            allowedToFire = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            allowedToFire = false;
        }
    }
}
