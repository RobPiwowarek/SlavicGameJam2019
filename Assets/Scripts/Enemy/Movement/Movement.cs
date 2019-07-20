using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public abstract class Movement : MonoBehaviour
{
    protected AttackTarget attackTarget;

    public virtual void Init(AttackTarget _attackTarget)
    {
        this.attackTarget = _attackTarget;
    }

    public abstract Vector2 Move(Vector2 current);

    public abstract UnityEngine.Quaternion Rotate(Vector2 current);
}