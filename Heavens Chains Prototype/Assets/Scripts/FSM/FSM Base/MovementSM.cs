using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public IdlePlayerState idleState;
    [HideInInspector]
    public MovingPlayerState movingState;

    private void Awake()
    {
        idleState = new IdlePlayerState(this);
        movingState = new MovingPlayerState(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}