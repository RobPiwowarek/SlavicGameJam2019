using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class Enemy : MonoBehaviour
{

    [SerializeField] protected AttackTarget attackTarget;
    
    [SerializeField] protected TargetSearchStrategy targetStrategy;
    [SerializeField] protected Movement movement;
    [SerializeField] protected AttackBehaviour attackBehaviour;
    
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected GameObject bullet;

    private void initializeBehaviors()
    {
        if (this.targetStrategy) this.targetStrategy.playerPosition = this.transform;
        
        if (this.attackTarget) this.movement.Init(this.attackTarget);
        if (this.attackBehaviour) this.attackBehaviour.Init(this.firePoint, this.bullet);
    }
    
    private void Start()
    {
        this.initializeBehaviors();
    }

    void Update()
    {
        if (this.targetStrategy)
        {
            AttackTarget newAttackTarget = this.targetStrategy.ScanTargets(this.attackTarget);
            if (newAttackTarget)
            {
                this.attackTarget = newAttackTarget;
                if (this.movement) this.movement.Init(this.attackTarget);
            }
        }
        if (this.attackBehaviour) this.attackBehaviour.TriggerAttack();
    }

    void FixedUpdate()
    {
        if (this.movement)
        {
            this.transform.position = this.movement.Move(this.transform.position);
        }
        if (this.attackBehaviour) this.attackBehaviour.Attack();
    }

}
