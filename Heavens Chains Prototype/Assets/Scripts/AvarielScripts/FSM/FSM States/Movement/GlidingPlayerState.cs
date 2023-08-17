using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlidingPlayerState : BaseState
{
    
    private MovementSM _sm;
    //private float counter;
    private string previousState;

    public GlidingPlayerState(MovementSM stateMachine, AvarielMain avarielMain) :base("Gliding", stateMachine, avarielMain)
    {
        this.stateName = "Gliding";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        //counter = 0;
        this.previousState = previousState;
        float mouseAngle = avarielMain.mousePos.getMouseAngle();
        Debug.Log("TEST: " + mouseAngle);
        avarielMain.rb.velocity = new Vector2(Mathf.Cos(mouseAngle) * avarielMain.glidePower, Mathf.Sin(mouseAngle) * avarielMain.glidePower);
        avarielMain.rb.gravityScale = 0;

        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        
    }

    public override void UpdatePhysics()
    {
    }

    public override void Exit()
    {
    }
}