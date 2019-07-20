using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController2D cc = other.transform.GetComponent<CharacterController2D>();
        if (cc)
        {
            cc.onLadder = true;
        }
        
        Rigidbody2D rb = other.transform.GetComponent<Rigidbody2D>();

        if (rb)
        {
            rb.gravityScale = 0f;
        }
        
        BoxCollider2D coll = other.transform.GetComponent<BoxCollider2D>();

        if (coll)
        {
            coll.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CharacterController2D cc = other.transform.GetComponent<CharacterController2D>();
        if (cc)
        {
            cc.onLadder = false;
        }

        Rigidbody2D rb = other.transform.GetComponent<Rigidbody2D>();

        if (rb)
        {
            rb.gravityScale = 1f;
            rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        }
        
        BoxCollider2D coll = other.transform.GetComponent<BoxCollider2D>();

        if (coll)
        {
            coll.isTrigger = false;
        }
    }
}
