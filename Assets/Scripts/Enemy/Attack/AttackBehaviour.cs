using UnityEngine;

// ATTENTION: AN ATTACK BEHAVIOUR MUST BE A CHILD OF ENEMY OBJECT ON THE SCENE

public abstract class AttackBehaviour: MonoBehaviour
{
    protected Transform firePoint;
    protected GameObject bullet;
    
    public virtual void Init(Transform _firePoint, GameObject _bullet)
    {
        this.firePoint = _firePoint;
        this.bullet = _bullet;
    }
    public abstract void TriggerAttack();
    public abstract void Attack();
}