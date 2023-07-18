using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FallingMovingPlayerState : BaseState
{
    
    private MovementSM _sm;
    private float moveSpeed;

    public FallingMovingPlayerState(MovementSM stateMachine, AvarielMain avarielMain) : base("Moving", stateMachine, avarielMain)
    {
    _sm = stateMachine;
    this.moveSpeed = avarielMain.moveSpeed;
    }

    public override void Enter()
    {
        rb.gravityScale = 1;
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        input = moveAction.ReadValue<Vector2>();
        if(input.sqrMagnitude == 0f) stateMachine.ChangeState(_sm.fallingIdleState);

        //State change logic -> Moving
        if(fallAction.triggered) stateMachine.ChangeState(_sm.movingState);
    }

    public override void UpdatePhysics()
    {
        rb.AddForce(input * (moveSpeed / 5) * Time.deltaTime);
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        rb.gravityScale = 0;
    }
}