using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FallingIdlePlayerState : AvarielMain
{
    
    private MovementSM _sm;

    public void Setup(MovementSM stateMachine, string stateName)
    {
        _sm = stateMachine;
        this.stateName = stateName;
    }

    public override void Enter(string previousState)
    {
        rb.gravityScale = 10;
        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        //State change logic -> Falling-Moving
        if(playerControls.moveAction.triggered) _sm.ChangeState(_sm.fallingMovingState);

        //State change logic -> Idle
        if(playerControls.fallAction.triggered) _sm.ChangeState(_sm.idleState);

        //State change logic -> Gliding
        if(playerControls.dashAction.triggered) _sm.ChangeState(_sm.glidingState);
    }

    public override void UpdatePhysics()
    {
        
    }

    public override void Exit()
    {
        rb.gravityScale = 0;
    }
}