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
        GameObject avariel = gameObject;
        idleState = avariel.AddComponent<IdlePlayerState>();
        idleState.Setup(this, "Idle");

        movingState = avariel.AddComponent<MovingPlayerState>();
        movingState.Setup(this, "Moving");

        fallingIdleState = avariel.AddComponent<FallingIdlePlayerState>();
        fallingIdleState.Setup(this, "Falling-Idle");

        fallingMovingState = avariel.AddComponent<FallingMovingPlayerState>();
        fallingMovingState.Setup(this, "Falling-Moving");

        dashingState = avariel.AddComponent<DashingPlayerState>();
        dashingState.Setup(this, "Dashing");

        glidingState = avariel.AddComponent<GlidingPlayerState>();
        glidingState.Setup(this, "Gliding");
        }

    protected override AvarielMain GetInitialState()
    {
        return idleState;
    }
}