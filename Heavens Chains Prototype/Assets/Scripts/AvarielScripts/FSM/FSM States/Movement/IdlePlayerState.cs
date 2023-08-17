using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdlePlayerState : BaseState
{

    private MovementSM _sm;

    public IdlePlayerState(MovementSM stateMachine, AvarielMain avarielMain) :base("Idle", stateMachine, avarielMain)
    {
        this.stateName = "Idle";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
        avarielMain.animator.Play("AvarielIdle");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if(avarielMain.playerControls.moveAction.triggered) _sm.ChangeState(_sm.movingState);
        
        //State change logic -> Falling
        if(avarielMain.playerControls.fallAction.triggered) _sm.ChangeState(_sm.fallingIdleState);

        //State change logic -> Dashing
        if(avarielMain.playerControls.dashAction.triggered) _sm.ChangeState(_sm.dashingState);
    }
}