using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public float restorePoints;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Repair key pressed");
            Health otherHealth = other.GetComponent<Health>();
            if (otherHealth)
            {
                Debug.Log("Restoring health");
                otherHealth.restoreHealth(restorePoints);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
