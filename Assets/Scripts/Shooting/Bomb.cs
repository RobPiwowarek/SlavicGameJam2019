using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Bomb : Bullet
{
    [SerializeField] private float splashRadius;
    [SerializeField] private float damageModifier;
    [SerializeField] private GameObject explosion;
    protected override void applyDamage(Collision2D other)
    {
        LayerMask mask = LayerMask.GetMask("Battle");
        List<Collider2D> hitColliders = Physics2D.OverlapCircleAll(other.transform.position, splashRadius, mask).ToList();
        
        hitColliders.ForEach(c =>
        {
            if (!c.CompareTag("Missile") && !c.CompareTag("Enemy"))
            {
                c.GetComponent<AttackTarget>()?.ReceiveDamage((int) (damageModifier * damage));
                Instantiate(explosion, c.transform.position, c.transform.rotation);
            }
        });

    }
}
