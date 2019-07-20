using UnityEngine;

public abstract class TargetSearchStrategy: MonoBehaviour
{
    public abstract AttackTarget FocusTarget();
    public abstract AttackTarget ScanTargets(AttackTarget currentTarget);
}