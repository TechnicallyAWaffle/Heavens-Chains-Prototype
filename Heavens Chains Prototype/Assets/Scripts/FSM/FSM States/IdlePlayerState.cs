using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdlePlayerState : BaseState
{

    private MovementSM _sm;
    public InputAction move;

    public IdlePlayerState(MovementSM stateMachine, AvarielMain avarielMain) : base("Idle", stateMachine, avarielMain) {_sm = stateMachine;}

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if(moveAction.triggered) stateMachine.ChangeState(_sm.movingState);
        
        //State change logic -> Falling
        if(fallAction.triggered) stateMachine.ChangeState(_sm.fallingIdleState);
    }

}