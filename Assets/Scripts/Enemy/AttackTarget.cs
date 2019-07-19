using UnityEngine;

public abstract class AttackTarget: MonoBehaviour
{
    public abstract void ReceiveDamage(int dmg);
}