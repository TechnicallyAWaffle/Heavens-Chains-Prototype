using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSM : StateMachine
{
    [HideInInspector]
    public MeleeIdlePlayerState meleeIdleState;
    [HideInInspector]
    public MeleeChargingPlayerState meleeChargingState;
    [HideInInspector]
    public MeleeAttackingPlayerState meleeAttackingState;
    [HideInInspector]
    public RangedIdlePlayerState rangedIdleState;
    [HideInInspector]
    public RangedDeployPlayerState rangedDeployState;
    [HideInInspector]
    public RangedAttackingPlayerState rangedAttackingState;

    private void Awake()
    {
       AvarielMain avarielMain = gameObject.GetComponent<AvarielMain>();
        meleeIdleState = new MeleeIdlePlayerState(this, avarielMain);
        meleeChargingState = new MeleeChargingPlayerState(this, avarielMain);
        meleeAttackingState = new MeleeAttackingPlayerState(this, avarielMain);
        rangedIdleState = new RangedIdlePlayerState(this, avarielMain);
        rangedDeployState = new RangedDeployPlayerState(this, avarielMain);
        rangedAttackingState = new RangedAttackingPlayerState(this, avarielMain);
        }

    protected override BaseState GetInitialState()
    {
        return meleeIdleState;
    }
}
