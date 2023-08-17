using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedDeployPlayerState : BaseState
{
    private CombatSM _sm;
    private float counter;
    private Transform ts;
    private string previousState;

    public RangedDeployPlayerState(CombatSM stateMachine, AvarielMain avarielMain) :base("Ranged-Deploy", stateMachine, avarielMain)
    {
        this.stateName = "Ranged-Deploy";
        _sm = stateMachine;
    }
    public override void Enter(string previousState)
    {
        Debug.Log("yippeee");
        avarielMain.activeWeapon.GetComponent<SpriteRenderer>().enabled = true;
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

    public override void Exit()
    {
    }
}
