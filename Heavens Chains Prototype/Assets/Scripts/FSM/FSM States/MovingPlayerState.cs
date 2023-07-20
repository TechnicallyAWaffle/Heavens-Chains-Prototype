using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingPlayerState : BaseState
{
    
    private MovementSM _sm;
    private float moveSpeed;

    public MovingPlayerState(MovementSM stateMachine, AvarielMain avarielMain) : base("Moving", stateMachine, avarielMain)
    {
    _sm = stateMachine;
    this.moveSpeed = avarielMain.moveSpeed;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        input = moveAction.ReadValue<Vector2>();
        if(input.sqrMagnitude == 0f) stateMachine.ChangeState(_sm.idleState);

        //State change logic -> Falling
        if(fallAction.triggered) stateMachine.ChangeState(_sm.fallingMovingState);
        
        //State change logic -> Dashing
        if(dashAction.triggered) stateMachine.ChangeState(_sm.dashingState);
        
    }

    public override void UpdatePhysics()
    {
        rb.AddForce(input * moveSpeed * Time.deltaTime);
        base.UpdatePhysics();
    }
}