using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FallingIdlePlayerState : BaseState
{
    
    private MovementSM _sm;

    public FallingIdlePlayerState(MovementSM stateMachine, AvarielMain avarielMain) :base("Falling-Idle", stateMachine, avarielMain)
    {
        this.stateName = "Falling-Idle";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        avarielMain.rb.gravityScale = 10;
        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        //State change logic -> Falling-Moving
        if(avarielMain.playerControls.moveAction.triggered) _sm.ChangeState(_sm.fallingMovingState);

        //State change logic -> Idle
        if(avarielMain.playerControls.fallAction.triggered) _sm.ChangeState(_sm.idleState);

        //State change logic -> Gliding
        if(avarielMain.playerControls.dashAction.triggered) _sm.ChangeState(_sm.glidingState);
    }

    public override void UpdatePhysics()
    {
        
    }

    public override void Exit()
    {
        avarielMain.rb.gravityScale = 0;
    }
}