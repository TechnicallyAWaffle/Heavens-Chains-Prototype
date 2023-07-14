using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdlePlayerState : BaseState
{

    private MovementSM _sm;
    public InputAction move;

    public IdlePlayerState(MovementSM stateMachine) : base("Idle", stateMachine) {_sm = stateMachine;}

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        stateMachine.ChangeState(_sm.movingState);
    }

}