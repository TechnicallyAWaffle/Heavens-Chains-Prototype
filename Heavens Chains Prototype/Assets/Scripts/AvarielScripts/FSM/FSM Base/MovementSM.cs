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
    [HideInInspector]
    public GlidingPlayerState glidingState;

    private void Awake()
    {
        AvarielMain avarielMain = gameObject.GetComponent<AvarielMain>();
        idleState = new IdlePlayerState(this, avarielMain);
        movingState = new MovingPlayerState(this, avarielMain);
        fallingIdleState = new FallingIdlePlayerState(this, avarielMain);
        fallingMovingState = new FallingMovingPlayerState(this, avarielMain);
        dashingState = new DashingPlayerState(this, avarielMain);
        glidingState = new GlidingPlayerState(this, avarielMain);
        }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}