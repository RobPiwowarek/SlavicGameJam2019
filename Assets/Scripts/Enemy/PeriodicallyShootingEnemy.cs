using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeriodicallyShootingEnemy : ShootingEnemy
{

    [SerializeField] private float seconds;

    private void Start()
    {
        StartCoroutine(CheckIfTimePassed());
    }

    IEnumerator CheckIfTimePassed() {
        for(;;)
        {
            fire = true;
            Attack();
            yield return new WaitForSeconds(seconds);
        }
    }
}
