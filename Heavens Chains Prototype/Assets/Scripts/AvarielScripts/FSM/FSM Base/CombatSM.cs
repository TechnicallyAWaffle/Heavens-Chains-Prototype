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
        GameObject avariel = gameObject;
        meleeIdleState = avariel.AddComponent<MeleeIdlePlayerState>();
        meleeIdleState.Setup(this, "Melee-Idle");

        meleeChargingState = avariel.AddComponent<MeleeChargingPlayerState>();
        meleeChargingState.Setup(this, "Melee-Charging");

        meleeAttackingState = avariel.AddComponent<MeleeAttackingPlayerState>();
        meleeAttackingState.Setup(this, "Melee-Attacking");

        rangedIdleState = avariel.AddComponent<RangedIdlePlayerState>();
        rangedIdleState.Setup(this, "Ranged-Idle");

        rangedDeployState = avariel.AddComponent<RangedDeployPlayerState>();
        rangedDeployState.Setup(this, "Ranged-Deploy");

        rangedAttackingState = avariel.AddComponent<RangedAttackingPlayerState>();
        rangedAttackingState.Setup(this, "Ranged-Attacking");
        }

    protected override AvarielMain GetInitialState()
    {
        return meleeIdleState;
    }
}
