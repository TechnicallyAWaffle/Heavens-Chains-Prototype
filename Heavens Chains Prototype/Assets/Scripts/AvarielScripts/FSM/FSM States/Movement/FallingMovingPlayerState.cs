using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FallingMovingPlayerState : BaseState
{
    
    private MovementSM _sm;
    private float counter;

    public FallingMovingPlayerState(MovementSM stateMachine, AvarielMain avarielMain) :base("Falling-Moving", stateMachine, avarielMain)
    {
        this.stateName = "Falling-Moving";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        avarielMain.rb.gravityScale = 10;
        base.Enter(previousState);
        counter = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        input = avarielMain.playerControls.moveAction.ReadValue<Vector2>();
        if(input.sqrMagnitude == 0f) _sm.ChangeState(_sm.fallingIdleState);

        //State change logic -> Moving
        if(avarielMain.playerControls.fallAction.triggered) _sm.ChangeState(_sm.movingState);

        //State change logic -> Gliding
        if(avarielMain.playerControls.dashAction.triggered) _sm.ChangeState(_sm.glidingState);
    }

    public override void UpdatePhysics()
    {
        if(counter <= 0.6) 
        {
            counter += Time.deltaTime;
            avarielMain.moveSpeed -= counter * 50;
            avarielMain.rb.AddForce(input * avarielMain.moveSpeed * Time.deltaTime);
        }
        else
            avarielMain.rb.AddForce(input * avarielMain.moveSpeed * Time.deltaTime);
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        avarielMain.rb.gravityScale = 0;
        avarielMain.moveSpeed = avarielMain.defaultMoveSpeed;
    }
}