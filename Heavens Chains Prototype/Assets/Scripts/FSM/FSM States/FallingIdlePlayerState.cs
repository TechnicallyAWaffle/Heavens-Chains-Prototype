using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FallingIdlePlayerState : BaseState
{
    
    private MovementSM _sm;
    private float moveSpeed;

    public FallingIdlePlayerState(MovementSM stateMachine, AvarielMain avarielMain) : base("Falling-Idle", stateMachine, avarielMain)
    {
    _sm = stateMachine;
    this.moveSpeed = avarielMain.moveSpeed;
    }

    public override void Enter(string previousState)
    {
        rb.gravityScale = 10;
        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if(moveAction.triggered) stateMachine.ChangeState(_sm.fallingMovingState);
        if(fallAction.triggered) stateMachine.ChangeState(_sm.idleState);
    }

    public override void UpdatePhysics()
    {
        
    }

    public override void Exit()
    {
        rb.gravityScale = 0;
    }
}