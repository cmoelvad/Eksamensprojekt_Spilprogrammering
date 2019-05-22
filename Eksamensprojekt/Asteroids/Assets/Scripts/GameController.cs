using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public  int score = 0;
    public  int money = 0;
    public  int health = 3;
    public  int shield = 100;

    public int asteroidPoints = 1;
    public int asteroidShieldDamage = 20;

    public  int getScore()
    {
        return score;
    }

    public  void increaseScore(int points)
    {
        score += points;
    }

    public  int getMoney()
    {
        return money;
    }

    public  void changeMoney(int amount)
    {
        money += amount;
    }

    public  int getHealth()
    {
        return health;
    }

    public  void changeHealth(int amount)
    {
        health += amount;
    }

    public  int getShield()
    {
        return shield;
    }

    public void changeShield(int amount)
    {
        shield += amount;
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
