using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingPlayerState : AvarielMain
{
    
    private MovementSM _sm;

    public void Setup(MovementSM stateMachine, string stateName)
    {
        _sm = stateMachine;
        this.stateName = stateName;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        input = playerControls.moveAction.ReadValue<Vector2>();
        if(input.sqrMagnitude == 0f) _sm.ChangeState(_sm.idleState);

        //State change logic -> Falling
        if(playerControls.fallAction.triggered) _sm.ChangeState(_sm.fallingMovingState);
        
        //State change logic -> Dashing
        if(playerControls.dashAction.triggered) _sm.ChangeState(_sm.dashingState);
        
    }

    public override void UpdatePhysics()
    {
        rb.AddForce(input * moveSpeed * Time.deltaTime);
        base.UpdatePhysics();
    }
}