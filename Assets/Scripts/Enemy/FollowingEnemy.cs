using UnityEngine;

public class FollowingEnemy : MovingEnemy
{
    public float minimumDistance;
    public float speed;

    public override void Move()
    {
        if (!attackTarget) return;
        
        if ((attackTarget.transform.position - transform.position).sqrMagnitude > minimumDistance)
        {
            this.transform.position = Vector3.MoveTowards(
                this.transform.position,
                this.attackTarget.transform.position,
                speed * Time.fixedDeltaTime
            );
        }
    }
}