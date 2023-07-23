using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdlePlayerState : AvarielMain
{

    private MovementSM _sm;
    public InputAction move;

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
        if(playerControls.moveAction.triggered) _sm.ChangeState(_sm.movingState);
        
        //State change logic -> Falling
        if(playerControls.fallAction.triggered) _sm.ChangeState(_sm.fallingIdleState);

        //State change logic -> Dashing
        if(playerControls.dashAction.triggered) _sm.ChangeState(_sm.dashingState);
    }

}