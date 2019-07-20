using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class OffensiveBuildData : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private float seconds;
    [SerializeField] private Transform firePoint;
    [SerializeField] private AttackTarget attackTarget;
    [SerializeField] private float searchRadius;

    private bool facedRight;
    void Start()
    {
        StartCoroutine(CheckIfTimePassed());
        facedRight = firePoint.position.x > this.transform.position.x;
    }

    private void FixedUpdate()
    {
        if (!attackTarget)
        {
            this.attackTarget = searchForEnemy();
            return;
        }
            UnityEngine.Quaternion newRotation = UnityEngine.Quaternion.LookRotation(
                attackTarget.transform.position - this.transform.position,
                Vector3.up
            );

            newRotation.x = 0.0f;
            newRotation.y = 0.0f;

            this.transform.rotation = newRotation;
            
            if (attackTarget)
            {
                if (this.transform.position.x > attackTarget.transform.position.x)
                {
                    transform.Rotate(0f, 180f, 0f);
                }
                else
                {
                    transform.Rotate(0f, 0f, 0f);
                }
            }

    }

    IEnumerator CheckIfTimePassed() {
        for(;;)
        {
            if (attackTarget) Instantiate(bullet, firePoint.position, firePoint.rotation).GetComponent<Transform>();
            yield return new WaitForSeconds(seconds);
        }
    }

    private AttackTarget searchForEnemy()
    {
        LayerMask mask = LayerMask.GetMask("Default");
        List<Collider2D> colliders = Physics2D.OverlapCircleAll(this.transform.position, searchRadius, mask)
            .Where(o => o.CompareTag("Enemy"))
            .OrderBy(o => (o.transform.position - this.transform.position).sqrMagnitude)
            .ToList();

        if (colliders.Count > 0) return colliders[0].GetComponent<AttackTarget>();
        return null;
    }
}