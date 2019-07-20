using System;
using UnityEngine;

public class BombingEnemy : PeriodicallyShootingEnemy
{
    public override void Attack()
    {
        AttackTarget attackTarget= this.GetComponentInParent<Enemy>().attackTarget;
        
        if (attackTarget)
        {
            float distance = Math.Abs(attackTarget.transform.position.x -
                                      this.firePoint.transform.position.x);
        
            if (fire && distance < 1.0f)
            {
                // TODO: drop bomb only above tower or something
                Transform obj = Instantiate(bullet, firePoint.position, firePoint.rotation).GetComponent<Transform>();
            }
        
            fire = false;
        }
    }
}