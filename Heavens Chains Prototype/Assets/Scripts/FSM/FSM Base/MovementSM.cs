using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public IdlePlayerState idleState;
    [HideInInspector]
    public MovingPlayerState movingState;
    [HideInInspector]
    public FallingIdlePlayerState fallingIdleState;
    [HideInInspector]
    public FallingMovingPlayerState fallingMovingState;
    [HideInInspector]
    public DashingPlayerState dashingState;

    private void Awake()
    {
        idleState = new IdlePlayerState(this, gameObject.GetComponent<AvarielMain>());
        movingState = new MovingPlayerState(this, gameObject.GetComponent<AvarielMain>());
        fallingIdleState = new FallingIdlePlayerState(this, gameObject.GetComponent<AvarielMain>());
        fallingMovingState = new FallingMovingPlayerState(this, gameObject.GetComponent<AvarielMain>());
        dashingState = new DashingPlayerState(this, gameObject.GetComponent<AvarielMain>());
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}