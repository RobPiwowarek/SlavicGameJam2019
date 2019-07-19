using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] protected AttackTarget attackTarget;
    [SerializeField] protected TargetSearchStrategy targetStrategy;

    private void Awake()
    {
        if (this.targetStrategy) this.targetStrategy.playerPosition = this.transform;
    }

    void Update()
    {
        if (this.targetStrategy)
        {
            AttackTarget newAttackTarget = this.targetStrategy.ScanTargets(this.attackTarget);
            if (newAttackTarget) this.attackTarget = newAttackTarget;
        }
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
