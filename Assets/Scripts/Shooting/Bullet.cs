﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigidbody;
    public float damage = 20f;

    public bool monetize = false;
    
    private void Start()
    {
        rigidbody.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        this.applyDamage(other);
        
        Destroy(gameObject);
    }

    protected virtual void applyDamage(Collision2D other)
    {
        AttackTarget enemy = other.collider.GetComponent<AttackTarget>();
        
        enemy?.ReceiveDamage((int)this.damage);

        if (monetize)
        {
            if (enemy.CompareTag("Enemy")) enemy?.ReceiveDamage((int)this.damage);
            FindObjectOfType<HappyTreeGameManager>().Money += 10f;
        }
        else
        {
            if (!enemy.CompareTag("Enemy")) enemy?.ReceiveDamage((int)this.damage);
        }

    }
}
