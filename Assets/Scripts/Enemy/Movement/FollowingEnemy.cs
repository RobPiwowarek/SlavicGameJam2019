using UnityEngine;

public class FollowingEnemy : Movement
{
    [SerializeField] protected float minimumDistance;
    [SerializeField] protected float distanceBuffer;
    [SerializeField] protected float speed;

    public override Vector3 Move(Vector3 current)
    {
        if (!attackTarget) return current;
        
        if ((attackTarget.transform.position - current).sqrMagnitude > minimumDistance)
        {
            return Vector3.MoveTowards(
                current,
                this.attackTarget.transform.position,
                speed * Time.fixedDeltaTime
            );
        }
        
        if ((attackTarget.transform.position - current).sqrMagnitude < minimumDistance)
        {
            return Vector3.MoveTowards(
                 current,
                this.attackTarget.transform.position,
                -1 * speed * Time.fixedDeltaTime
            );
        }

        return current;
    }
}