using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DashingPlayerState : AvarielMain
{
    
    private MovementSM _sm;
    private float counter;
    private string previousState;

    public void Setup(MovementSM stateMachine, string stateName)
    {
        _sm = stateMachine;
        this.stateName = stateName;
    }

    public override void Enter(string previousState)
    {
        counter = 0;
        this.previousState = previousState;
        input = playerControls.moveAction.ReadValue<Vector2>();
        rb.velocity = new Vector2(input.x * dashPower, input.y * dashPower);
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