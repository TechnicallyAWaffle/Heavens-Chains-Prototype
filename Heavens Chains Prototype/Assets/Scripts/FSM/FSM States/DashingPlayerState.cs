using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashingPlayerState : BaseState
{
    
    private MovementSM _sm;
    private float dashPower;
    private float counter;
    private string previousState;

    public DashingPlayerState(MovementSM stateMachine, AvarielMain avarielMain) : base("Dashing", stateMachine, avarielMain)
    {
        _sm = stateMachine;
        this.dashPower = avarielMain.dashPower;
    }

    public override void Enter(string previousState)
    {
        counter = 0;
        Debug.Log("previous state: " + previousState);
        this.previousState = previousState;
        input = moveAction.ReadValue<Vector2>();
        rb.velocity = new Vector2(input.x * dashPower, input.y * dashPower);
        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        if(counter > 0.25)
        {
            if(previousState == "Moving") stateMachine.ChangeState(_sm.movingState);
            else if(previousState == "Idle") stateMachine.ChangeState(_sm.idleState);
        }
        counter += Time.deltaTime;
    }

    public override void UpdatePhysics()
    {
    }

    public override void Exit()
    {
    }
}