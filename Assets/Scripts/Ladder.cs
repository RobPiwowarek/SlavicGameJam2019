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
            rb.gravityScale = 1f;
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
            rb.gravityScale = 0f;
        }
    }
}
