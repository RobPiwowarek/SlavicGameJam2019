using UnityEngine;

public abstract class MovingEnemy : MonoBehaviour
{
    public AttackTarget attackTarget;
    public abstract void Move();
}