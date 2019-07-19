using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public float price;
    public BasicBuild build;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButton("ActionButton") && gameObject.transform.childCount < 1)
        {
            var basicBuild = Instantiate ( build, gameObject.transform );
            basicBuild.transform.parent = gameObject.transform;
        }
    }
}
