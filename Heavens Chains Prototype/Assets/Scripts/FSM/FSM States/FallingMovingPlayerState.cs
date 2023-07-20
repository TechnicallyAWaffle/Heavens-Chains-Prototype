using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FallingMovingPlayerState : BaseState
{
    
    private MovementSM _sm;
    private float moveSpeed;
    private int counter;

    public FallingMovingPlayerState(MovementSM stateMachine, AvarielMain avarielMain) : base("Falling-Moving", stateMachine, avarielMain)
    {
    _sm = stateMachine;
    this.moveSpeed = avarielMain.moveSpeed;
    }

    public override void Enter(string previousState)
    {
        rb.gravityScale = 10;
        base.Enter(previousState);
        counter = 1;
    }

    public override void UpdateLogic()
    {
        counter++;
        base.UpdateLogic();
        input = moveAction.ReadValue<Vector2>();
        if(input.sqrMagnitude == 0f) stateMachine.ChangeState(_sm.fallingIdleState);

        //State change logic -> Moving
        if(fallAction.triggered) stateMachine.ChangeState(_sm.movingState);
    }

    public override void UpdatePhysics()
    {
        Debug.Log(counter);
        if(counter <= 200) 
        {
            rb.AddForce(input * (moveSpeed - (counter * 25)) * Time.deltaTime);
        }
        else
            rb.AddForce(input * 2500 * Time.deltaTime);
        base.UpdatePhysics();
    }

    public override void Exit()
    {
        rb.gravityScale = 0;
    }
}