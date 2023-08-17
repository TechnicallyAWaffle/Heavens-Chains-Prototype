using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingPlayerState : BaseState
{
    
    private MovementSM _sm;

    public MovingPlayerState(MovementSM stateMachine, AvarielMain avarielMain) :base("Moving", stateMachine, avarielMain)
    {
        this.stateName = "Moving";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        input = avarielMain.playerControls.moveAction.ReadValue<Vector2>();
        if(input.sqrMagnitude == 0f) _sm.ChangeState(_sm.idleState);

        //State change logic -> Falling
        if(avarielMain.playerControls.fallAction.triggered) _sm.ChangeState(_sm.fallingMovingState);
        
        //State change logic -> Dashing
        if(avarielMain.playerControls.dashAction.triggered) _sm.ChangeState(_sm.dashingState);
        
    }

    public override void UpdatePhysics()
    {
        avarielMain.rb.AddForce(input * avarielMain.moveSpeed * Time.deltaTime);
        base.UpdatePhysics();
    }
}