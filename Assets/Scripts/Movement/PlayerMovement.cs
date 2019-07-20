using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; // publiczne sa widoczne w unity

    public float runSpeed = 40f;
    public String moveCode;
    public String jumpCode;
    public String ladderMoveCode;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw(moveCode) * runSpeed;   // lewo -1 1 prawo 
        verticalMove = Input.GetAxisRaw(ladderMoveCode) * runSpeed;   // dół -1 1 góra 
        if (Input.GetButtonDown(jumpCode)) // czemu jump? edit -> project settings -> input
        {
            jump = true;
        }
    }

    // called fixed amount of time per second, dedicated to physics
    // generally for movement
    void FixedUpdate()
    {
        if (!controller.onLadder)
        {
            // fixed delta time to ile czasu minelo od ostatniego czasu kiedy ta funkcja zostala wywolana, wiec daje to staly speed niezaleznie od tego ile razy to jest wolane
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        }
        else
        {
            controller.MoveOnLadder(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
        }
        
        jump = false;
    }

    
}
