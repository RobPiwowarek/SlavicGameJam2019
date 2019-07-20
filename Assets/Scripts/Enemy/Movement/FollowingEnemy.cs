using UnityEngine;

public class FollowingEnemy : Movement
{
    public float minimumDistance;
    public float speed;

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

        return current;
    }
}