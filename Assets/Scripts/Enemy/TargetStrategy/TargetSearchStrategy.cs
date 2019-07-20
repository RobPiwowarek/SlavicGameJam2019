using UnityEngine;

public abstract class TargetSearchStrategy: MonoBehaviour
{
    public Transform playerPosition;
    public abstract AttackTarget FocusTarget();
    public abstract AttackTarget ScanTargets(AttackTarget currentTarget);
}