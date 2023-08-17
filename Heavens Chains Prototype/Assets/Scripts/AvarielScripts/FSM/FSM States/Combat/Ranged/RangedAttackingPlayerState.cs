using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackingPlayerState : BaseState
{
    private CombatSM _sm;
    private float counter;
    private string previousState;

    public RangedAttackingPlayerState(CombatSM stateMachine, AvarielMain avarielMain) :base("Ranged-Attacking", stateMachine, avarielMain)
    {
        this.stateName = "Ranged-Attacking";
        _sm = stateMachine;
    }

    public override void Enter(string previousState)
    {
        base.Enter(previousState);
        avarielMain.activeWeapon.GetComponent<IWeaponReference>().Attack();
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
