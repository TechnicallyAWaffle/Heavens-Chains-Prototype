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

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        input = moveAction.ReadValue<Vector2>();
        if(input.sqrMagnitude == 0f) stateMachine.ChangeState(_sm.idleState);
    }

    public override void UpdatePhysics()
    {
        rb.AddForce(input * moveSpeed * Time.deltaTime);
        base.UpdatePhysics();
    }
}