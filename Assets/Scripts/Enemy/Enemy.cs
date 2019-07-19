using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] protected AttackTarget attackTarget;

    void Update()
    {
        this.TriggerAttack();
    }

    void FixedUpdate()
    {
        Attack();
    }

    protected abstract void TriggerAttack();

    protected virtual void Attack()
    {
    }

}
