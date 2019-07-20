using System;
using UnityEngine;

public class HoveringEnemy: Movement
{
    [SerializeField] protected float distanceBuffer;
    [SerializeField] protected float yDistance;
    [SerializeField] protected float speed;
    
    // Hover parameters
    [SerializeField] private float Amplitude;
    
    // Scanning parameters
    [SerializeField] private bool goRight = true ;
    [SerializeField] private float scanDistance;
    [SerializeField] private Vector2 scanRightPosition;
    [SerializeField] private Vector2 scanLeftPosition;

    [SerializeField] private Enemy enemy;

    public void Start()
    {
        this.enemy = GetComponentInParent<Enemy>();
    }

    public override Vector2 Move(Vector2 current)
    {
        if (attackTarget)
        {
            
            scanRightPosition = new Vector2(current.x + scanDistance, current.y);
            scanLeftPosition = new Vector2(current.x - scanDistance, current.y);

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


        /*if (goRight && enemy)
        {
            if ((current - scanRightPosition).sqrMagnitude < distanceBuffer)
            {
                goRight = false;
                enemy.flipped = true;
            }
            return Vector2.MoveTowards(current, scanRightPosition,
                speed * Time.fixedDeltaTime);
        }
        else if (enemy)
        {
            if ((current - scanLeftPosition).sqrMagnitude < distanceBuffer)
            {
                goRight = true;
                enemy.flipped = false;
            }
            return Vector2.MoveTowards(current, scanLeftPosition,
                speed * Time.fixedDeltaTime);
        }*/

        return current;

    }

    public override UnityEngine.Quaternion Rotate(Vector2 current)
    {
        return Quaternion.identity;
    }
}