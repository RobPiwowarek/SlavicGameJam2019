using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    protected AttackTarget attackTarget;

    public virtual void Init(AttackTarget _attackTarget)
    {
        this.attackTarget = _attackTarget;
    }

    public virtual Vector3 Move(Vector3 current)
    {
        return current;
    }
}