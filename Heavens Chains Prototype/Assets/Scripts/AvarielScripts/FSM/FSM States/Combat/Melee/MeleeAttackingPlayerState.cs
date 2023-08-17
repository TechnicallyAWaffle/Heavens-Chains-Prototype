using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackingPlayerState : BaseState
{
    private CombatSM _sm;
    private float counter;

    public MeleeAttackingPlayerState(CombatSM stateMachine, AvarielMain avarielMain) :base("Melee-Attacking", stateMachine, avarielMain)
    {
        this.stateName = "Melee-Attacking";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
        avarielMain.animator.Play("AvarielSwordAttack");
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
