using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildSlot : MonoBehaviour
{
    public Rigidbody2D Buildable;

    bool IsTaken()
    {
        return this.transform.childCount > 0;
    }

    void SpawnChild()
    {
        if (this.IsTaken())
        {
            Debug.LogError("This build slot already has a building");
        }
        else if (!Buildable)
        {
            Debug.LogError("Buildable not set");
        }
        else
        {
            Debug.Log("Spawning building");
            Rigidbody2D p = Instantiate(Buildable, this.transform.position, this.transform.rotation, this.transform);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
