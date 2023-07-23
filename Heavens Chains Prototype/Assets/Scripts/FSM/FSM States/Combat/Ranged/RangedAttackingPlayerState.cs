using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackingPlayerState : AvarielMain
{
    private CombatSM _sm;
    private float counter;

    public void Setup(CombatSM stateMachine, string stateName) 
    {
        _sm = stateMachine;
        this.stateName = stateName;
    }

    public override void Enter(string previousState)
    {
        counter = 0;
        base.Enter(previousState);
    }

    public override void UpdateLogic()
    {
        if (counter > 0.25)
        {
            _sm.ChangeState(_sm.rangedIdleState);
            counter = 0;
            
        }
        counter += Time.deltaTime;
    }
}
