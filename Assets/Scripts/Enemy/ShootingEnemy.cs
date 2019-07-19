using System;
using UnityEngine;

public class ShootingEnemy: Enemy
{
    [SerializeField] private Transform firePoint;
    public GameObject bullet;
    protected Boolean fire = false;
    protected override void TriggerAttack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fire = true;
        }
    }

    protected override void Attack()
    {
        if (fire)
        {
            Transform obj = Instantiate(bullet, firePoint.position, firePoint.rotation).GetComponent<Transform>();
        }
        
        fire = false;
    }
}