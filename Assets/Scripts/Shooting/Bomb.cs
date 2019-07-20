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
    protected override void applyDamage(Collision2D other)
    {
        LayerMask mask = LayerMask.GetMask("Default");
        List<Collider2D> hitColliders = Physics2D.OverlapCircleAll(other.transform.position, splashRadius, mask).ToList();
        
        hitColliders.ForEach(c => c.GetComponent<AttackTarget>()?.ReceiveDamage((int)(damageModifier * damage)));
            
    }
}
