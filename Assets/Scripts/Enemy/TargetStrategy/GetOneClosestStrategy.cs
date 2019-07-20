using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Object = System.Object;

public class GetOneClosestStrategy : TargetSearchStrategy
{
    private List<AttackTarget> attackTargets;

    public void Start()
    {
        RescanAttackTargets();
    }

    public override AttackTarget FocusTarget()
    {
        return this.attackTargets.Count > 0 ? this.attackTargets[0] : null;
    }

    public override AttackTarget ScanTargets(AttackTarget currentTarget)
    {
        if (!currentTarget || !currentTarget.isActiveAndEnabled)
        {
            RescanAttackTargets();
            return FocusTarget();
        }

        return null;
    }

    private void RescanAttackTargets()
    {
        this.attackTargets = FindObjectsOfType<AttackTarget>()
            .Where(t => t.transform.position != playerPosition.position && t.CompareTag("Building"))
            .OrderBy(t => (t.transform.position - playerPosition.position).sqrMagnitude)
            .ToList();
    }
}