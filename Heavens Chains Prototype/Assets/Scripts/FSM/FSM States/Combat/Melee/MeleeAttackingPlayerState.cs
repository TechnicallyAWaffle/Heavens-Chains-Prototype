using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackingPlayerState : AvarielMain
{
    private CombatSM _sm;
    private float count;

    public void Setup(CombatSM stateMachine, string stateName) 
    {
        _sm = stateMachine;
        this.stateName = stateName;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
        
    }

    public override void UpdateLogic()
    {
        count = 0;
        while (count < 5)
        {
            count += Time.deltaTime;
        }
        _sm.ChangeState(_sm.meleeIdleState);
    }
}
