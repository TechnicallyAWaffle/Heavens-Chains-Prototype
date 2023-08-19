using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskAttack : Node
{
    private Transform _lastTarget;
    private AttackManager _attackManager;
    private GameObject _activeWeapon;
    //private GuardianAngelBT _guardianAngelBT;

     public TaskAttack(AttackManager attackManager, GameObject activeWeapon)
    {
        _attackManager = attackManager;
        _activeWeapon = activeWeapon;
    }

    public override NodeState Evaluate()
    {
        Transform target = GetData<Transform>("target");
        if (target != null)
        {
            //_attackManager.RunEnemyAttackAnimation("Attack", _activeWeapon);      
        }

        state = NodeState.RUNNING;
        return state;
    }
}