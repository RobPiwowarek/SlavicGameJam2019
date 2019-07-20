using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class FollowingEnemy : Movement
{
    [SerializeField] protected float minimumDistance;
    [SerializeField] protected float distanceBuffer;
    [SerializeField] protected float speed;

    public override Vector2 Move(Vector2 current)
    {
        if (!attackTarget) return current;

        Vector2 targetPosition = attackTarget.transform.position;
        
        if ((((Vector2)attackTarget.transform.position - (Vector2)current)).sqrMagnitude > minimumDistance)
        {
            Vector2 result = Vector2.MoveTowards(
                current,
                this.attackTarget.transform.position,
                speed * Time.fixedDeltaTime
            );

            return result;
        }
        
        if (((Vector2)attackTarget.transform.position - (Vector2)current).sqrMagnitude < minimumDistance)
        {
            Vector2 result = Vector2.MoveTowards(
                 current,
                this.attackTarget.transform.position,
                -1 * speed * Time.fixedDeltaTime
            );

            return result;
        }

        return current;
    }

    public override UnityEngine.Quaternion Rotate(Vector2 current)
    {
        if (attackTarget)
        {

            UnityEngine.Quaternion newRotation = UnityEngine.Quaternion.LookRotation((Vector2) attackTarget.transform.position- current, Vector3.up);
            newRotation.x = 0.0f;
            newRotation.y = 0.0f;

            return newRotation;
        }
        else return UnityEngine.Quaternion.identity;
    }
}