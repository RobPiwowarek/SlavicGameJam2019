using UnityEngine;

public class AttackTarget: MonoBehaviour
{
    public void receiveDamage(int dmg)
    {
        Debug.Log("Received " + dmg + " of damage");
    }
}