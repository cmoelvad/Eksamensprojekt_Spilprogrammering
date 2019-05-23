﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void takeDamage(int damage);

    void shoot();

    int getMoneyWorth();
}
