using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashingPlayerState : BaseState
{
    
    private MovementSM _sm;
    private float counter;
    private string previousState;

    public DashingPlayerState(MovementSM stateMachine, AvarielMain avarielMain) :base("Dashing", stateMachine, avarielMain)
    {
        this.stateName = "Dashing";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        counter = 0;
        this.previousState = previousState;
        input = avarielMain.playerControls.moveAction.ReadValue<Vector2>();
        avarielMain.rb.velocity = new Vector2(input.x * avarielMain.dashPower, input.y * avarielMain.dashPower);
        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        if(counter > 0.25)
        {
            if(previousState == "Moving") _sm.ChangeState(_sm.movingState);
            else if(previousState == "Idle") _sm.ChangeState(_sm.idleState);
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