using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class Enemy : MonoBehaviour
{

    public AttackTarget attackTarget;
    
    [SerializeField] protected TargetSearchStrategy targetStrategy;
    [SerializeField] protected Movement movement;
    [SerializeField] protected AttackBehaviour attackBehaviour;
    
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected GameObject bullet;

    public bool flipped = false;
    public bool idle = false;

    private void initializeBehaviors()
    {
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
            Transform currentTransform = this.transform;
            this.transform.position = this.movement.Move(currentTransform.position);

            Quaternion newRotation = this.movement.Rotate(currentTransform.position);

            // TODO: make smooth rotations
            /*this.transform.rotation = UnityEngine.Quaternion.Slerp(currentTransform.rotation,
                newRotation, Time.fixedDeltaTime);*/

            this.transform.rotation = newRotation;

            if (this.attackBehaviour) this.attackBehaviour.Attack();
        }
        
        if (attackTarget)
        {
            if (this.transform.position.x > attackTarget.transform.position.x)
            {
                this.flipped = true;
            }
            else
            {
                this.flipped = false;
            }
        }

        if (this.flipped)
        {
            transform.Rotate(0f, 180f, 0f);
        }

    }

}
