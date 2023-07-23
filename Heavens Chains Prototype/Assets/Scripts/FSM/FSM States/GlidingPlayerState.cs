using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlidingPlayerState : AvarielMain
{
    
    private MovementSM _sm;
    //private float counter;
    private string previousState;

    public void Setup(MovementSM stateMachine, string stateName)
    {
        _sm = stateMachine;
        this.stateName = stateName;
    }

    public override void Enter(string previousState)
    {
        //counter = 0;
        this.previousState = previousState;
        float mouseAngle = mousePos.getMouseAngle();
        Debug.Log("TEST: " + mouseAngle);
        rb.velocity = new Vector2(Mathf.Cos(mouseAngle) * glidePower, Mathf.Sin(mouseAngle) * glidePower);
        rb.gravityScale = 0;

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