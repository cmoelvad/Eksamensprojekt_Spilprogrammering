using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanctuary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IWhitelist whitelisted = collision.GetComponent<IWhitelist>();
        if(whitelisted == null)
        {
            Destroy(collision.gameObject);
        }
    }
}
