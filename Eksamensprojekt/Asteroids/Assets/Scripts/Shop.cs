using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour, IWhitelist
{
    public Canvas shopCanvas;

    public int shieldPowerUpPrize = 10;
    public int specialAmmoPrice = 10;
    public int upgradeMaxShield = 15;

    private GameController gc;
    private FadeShield shield;
    private bool canBuy; 
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameController>();
        shield = FindObjectOfType<FadeShield>();
        shopCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canBuy)
        {
            if (Input.GetButtonDown("Buy1") && gc.money >= shieldPowerUpPrize)
            {
                gc.money -= shieldPowerUpPrize;
                shield.updateShieldHealth(gc.asteroidShieldDamage);
            }
            else if (Input.GetButtonDown("Buy2") && gc.money >= specialAmmoPrice)
            {
                gc.money -= specialAmmoPrice;
                gc.specialAmmo += 1;
            }
            else if (Input.GetButtonDown("Buy3") && gc.money >= upgradeMaxShield)
            {
                gc.money -= upgradeMaxShield;
                gc.maxShield += gc.asteroidShieldDamage;
                shield.updateShieldHealth(gc.asteroidShieldDamage);
            }

        }
        Text text = shopCanvas.GetComponentInChildren<Text>();
        text.text = "Options: " +
                    "\n" +
                    "\nPress F to buy Shield power up for " + shieldPowerUpPrize + " coins" +
                    "\nPress G to buy Weapon power up for " + specialAmmoPrice + " coins" +
                    "\nPress H to upgrade Shield for " + upgradeMaxShield + " coins" +
                    "\n" +
                    "\nCurrent Balance: " + gc.money;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            shopCanvas.gameObject.SetActive(true);
            canBuy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            shopCanvas.gameObject.SetActive(false);
            canBuy = false;
        }
    }
}
