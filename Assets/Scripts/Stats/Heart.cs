using UnityEngine;
using UnityEngine.PlayerLoop;

public class Heart : Health
{

    [SerializeField] private Collider2D _collider2D;
    
    public void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Building").Length == 0)
        {
            _collider2D.isTrigger = false;
        }
        else
        {
            _collider2D.isTrigger = true;
        }
    }
}