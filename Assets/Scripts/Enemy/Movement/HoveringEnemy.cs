using System;
using UnityEngine;

public class HoveringEnemy: Movement
{
    [SerializeField] protected float distanceBuffer;
    [SerializeField] protected float yDistance;
    [SerializeField] protected float speed;
    [SerializeField] private float Amplitude;
    
    public override Vector2 Move(Vector2 current)
    {
        if (attackTarget)
        {
            Vector2 targetPosition = attackTarget.transform.position;
        
            if (Math.Abs(attackTarget.transform.position.x - current.x) > distanceBuffer || 
                current.y - attackTarget.transform.position.y > yDistance + distanceBuffer ||
                current.y < attackTarget.transform.position.y)
            {
                Vector2 result = Vector2.MoveTowards(
                    current,
                    (Vector2)this.attackTarget.transform.position + new Vector2(0.0f, yDistance),
                    speed * Time.fixedDeltaTime
                );

                return result;
            }
        
            if (current.y - attackTarget.transform.position.y < yDistance - distanceBuffer)
            {
                Vector2 result = Vector2.MoveTowards(
                    current,
                    (Vector2)this.attackTarget.transform.position + new Vector2(0.0f, yDistance),
                    -1 * speed * Time.fixedDeltaTime
                );

                return result;
            }
        }

        return new Vector2(current.x, current.y + Amplitude * Mathf.Sin(speed * Time.fixedTime));

        return current;
    }

    public override UnityEngine.Quaternion Rotate(Vector2 current)
    {
        return Quaternion.identity;
    }
}