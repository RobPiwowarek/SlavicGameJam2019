using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ATTENTION: AN ATTACK BEHAVIOUR MUST BE A CHILD OF ENEMY OBJECT ON THE SCENE

public class PeriodicallyShootingEnemy : ShootingEnemy
{

    [SerializeField] protected float seconds;
    private HappyTreeGameManager gm;

    public void Start()
    {
        gm = GameObject.Find("HappyTreeGameManager").GetComponent<HappyTreeGameManager>();
    }

    public override void Init(Transform _firePoint, GameObject _bullet)
    {
        base.Init(_firePoint, _bullet);
        StartCoroutine(CheckIfTimePassed());
    }

    IEnumerator CheckIfTimePassed() {
        for(;;)
        {
            fire = true;
            Attack();
            if (this.gameObject.CompareTag("Building"))
                yield return new WaitForSeconds(seconds * gm.attackSpeedModifier);
            else
                yield return new WaitForSeconds(seconds);
        }
    }
    
    public override void TriggerAttack()
    {
    }
}
