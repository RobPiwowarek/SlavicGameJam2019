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
    [SerializeField] private bool flipped;

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
                (Vector2) attackTarget.transform.position - (Vector2) this.transform.position);

            newRotation.x = 0.0f;
            newRotation.y = 0.0f;

            this.transform.rotation = newRotation;

            if (this.flipped)
            {
                this.transform.Rotate(0f, 180f, 0f);
            }
            else
            {
                this.transform.Rotate(0f, 0f, 0f);
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

        if (colliders.Count > 0)
        {
            AttackTarget target = colliders[0].GetComponent<AttackTarget>();
            
                if (this.transform.position.x > target.transform.position.x)
                {
                    this.flipped = true;
                }
                else
                {
                    this.flipped = false;
                }

                return target;
        }
        return null;
    }
}