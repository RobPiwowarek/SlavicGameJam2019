using System;
using UnityEngine;

public class BombingEnemy : PeriodicallyShootingEnemy
{

    private Enemy enemy;
    private AttackTarget attackTarget;
    
    public override void Attack()
    {
        this.enemy = this.GetComponentInParent<Enemy>();
        if (this.enemy) this.attackTarget = enemy.attackTarget;
        
        if (attackTarget)
        {
            float distance = Math.Abs(attackTarget.transform.position.x -
                                      this.firePoint.transform.position.x);
        
            if (fire && distance < 1.0f)
            {
                Transform obj = Instantiate(bullet, firePoint.position, firePoint.rotation).GetComponent<Transform>();
            }
        
            fire = false;
        }
    }
}