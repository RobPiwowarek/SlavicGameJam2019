using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    [SerializeField] protected AttackTarget attackTarget;
    [SerializeField] protected TargetSearchStrategy targetStrategy;
    private MovingEnemy movement;

    private void Awake()
    {
        if (this.targetStrategy) this.targetStrategy.playerPosition = this.transform;
        this.movement = this.GetComponent<MovingEnemy>();
    }

    void Update()
    {
        if (this.targetStrategy)
        {
            AttackTarget newAttackTarget = this.targetStrategy.ScanTargets(this.attackTarget);
            if (newAttackTarget)
            {
                this.attackTarget = newAttackTarget;
                if (this.movement) movement.attackTarget = this.attackTarget;
            }
        }
        this.TriggerAttack();
    }

    void FixedUpdate()
    {
        if (this.movement) this.movement.Move();
        Attack();
    }

    protected abstract void TriggerAttack();

    protected virtual void Attack()
    {
    }

}
