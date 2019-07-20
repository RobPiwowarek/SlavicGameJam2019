using System;
using UnityEngine;

// ATTENTION: AN ATTACK BEHAVIOUR MUST BE A CHILD OF ENEMY OBJECT ON THE SCENE

public class ShootingEnemy: AttackBehaviour
{
    protected Boolean fire = false;
    public override void TriggerAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fire = true;
        }
    }

    public override void Attack()
    {
        if (fire)
        {
            Transform obj = Instantiate(bullet, firePoint.position, firePoint.rotation).GetComponent<Transform>();
        }
        
        fire = false;
    }
}