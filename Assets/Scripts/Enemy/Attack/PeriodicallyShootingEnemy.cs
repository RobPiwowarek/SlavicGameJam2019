using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ATTENTION: AN ATTACK BEHAVIOUR MUST BE A CHILD OF ENEMY OBJECT ON THE SCENE

public class PeriodicallyShootingEnemy : ShootingEnemy
{

    [SerializeField] private float seconds;

    public override void Init(Transform _firePoint, GameObject _bullet)
    {
        base.Init(_firePoint, _bullet);
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
    
    public override void TriggerAttack()
    {
    }
}
