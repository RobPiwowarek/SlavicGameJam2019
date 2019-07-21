using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetOneClosestStrategy : TargetSearchStrategy
{
    private List<AttackTarget> attackTargets;

    public void Start()
    {
        RescanAttackTargets();
    }

    public void Update()
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
        Debug.Log(GameObject.FindGameObjectsWithTag("Building").Length);
        
        this.attackTargets = GameObject.FindGameObjectsWithTag("Building")
            .Select(o => o.GetComponentInChildren<AttackTarget>())
            .OrderBy(o => (o.transform.position - this.transform.position).sqrMagnitude)
            .ToList();

        if (this.attackTargets.Count == 0)
            this.attackTargets =
                new List<AttackTarget>() {GameObject.FindWithTag("Hearth").GetComponent<AttackTarget>()};

    }
}