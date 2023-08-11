using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackingPlayerState : AvarielMain
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
        base.Enter(previousState);
        animator.Play("AvarielSwordAttack");
    }

    public override void UpdateLogic()
    {
        if (counter > 0.25)
        {
            _sm.ChangeState(_sm.meleeIdleState);
            counter = 0;
            
        }
        counter += Time.deltaTime;
    }
}
