using System.Collections.Generic;
using System.Linq;

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
            .Where(o => o.CompareTag("Building") && o.GetComponent<AttackTarget>())
            .Select(o => o.GetComponent<AttackTarget>())
            .OrderBy(o => (o.transform.position - this.transform.position).sqrMagnitude)
            .ToList();
        
        if (this.attackTargets.Count == 0) this.attackTargets = FindObjectsOfType<AttackTarget>()
            .Where(o => o.CompareTag("Hearth") && o.GetComponent<AttackTarget>())
            .Select(o => o.GetComponent<AttackTarget>())
            .OrderBy(o => (o.transform.position - this.transform.position).sqrMagnitude)
            .ToList();
        
    }
}