using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FallingMovingPlayerState : AvarielMain
{
    
    private MovementSM _sm;
    private float counter;

    public void Setup(MovementSM stateMachine, string stateName)
    {
        _sm = stateMachine;
        this.stateName = stateName;
    }

    public override void Enter(string previousState)
    {
        rb.gravityScale = 10;
        base.Enter(previousState);
        counter = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        input = playerControls.moveAction.ReadValue<Vector2>();
        if(input.sqrMagnitude == 0f) _sm.ChangeState(_sm.fallingIdleState);

        //State change logic -> Moving
        if(playerControls.fallAction.triggered) _sm.ChangeState(_sm.movingState);

        //State change logic -> Gliding
        if(playerControls.dashAction.triggered) _sm.ChangeState(_sm.glidingState);
    }

    public override void UpdatePhysics()
    {
        if(counter <= 0.6) 
        {
            counter += Time.deltaTime;
            Debug.Log(moveSpeed);
            moveSpeed -= counter * 50;
            rb.AddForce(input * moveSpeed * Time.deltaTime);
        }
        else
            rb.AddForce(input * moveSpeed * Time.deltaTime);
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        rb.gravityScale = 0;
        moveSpeed = defaultMoveSpeed;
    }
}