using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : AttackTarget
{
    public float healthPoints = 50;
    public float maxHealthPoints = 50;
    private Boolean isDead;

    public override void ReceiveDamage(int dmg)
    {
        this.takeDamage(dmg);
    }

    public void takeDamage(float damage)
    {
        healthPoints -= damage;

        if (healthPoints < 0)
            isDead = true;
    }

    public void restoreHealth(float health)
    {
        if (health + healthPoints > maxHealthPoints)
            healthPoints = maxHealthPoints;
        else
        {
            healthPoints = healthPoints + health;
        }
    }

    public float maxHealth
    {
        get { throw new NotImplementedException(); }
        set { maxHealthPoints = value; }
    }

    public void Update()
    {
        if (isDead)
            Destroy(gameObject);
    }

    public bool IsDead
    {
        get { return isDead; }
    }
}