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
        LayerMask mask = LayerMask.GetMask("Battle");
        
        this.attackTargets = Physics2D.OverlapCircleAll(this.transform.position, 100.0f, mask)
            .Where(o => o.CompareTag("Building") && o.GetComponent<AttackTarget>())
            .Select(o => o.GetComponent<AttackTarget>())
            .OrderBy(o => (o.transform.position - this.transform.position).sqrMagnitude)
            .ToList();
        
    }
}