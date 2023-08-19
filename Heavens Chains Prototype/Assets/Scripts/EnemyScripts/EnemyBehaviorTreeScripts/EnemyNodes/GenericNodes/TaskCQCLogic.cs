using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskCQCLogic : Node
{
    private Transform _transform;
    //private Animator _animator;
    private EnemyConfig _enemyConfig;

    public TaskCQCLogic(Transform transform, EnemyConfig enemyConfig)
    {
        _transform = transform;
        //_animator = transform.GetComponent<Animator>();
        _enemyConfig = enemyConfig;
    }

    public override NodeState Evaluate()
    {
        Transform target = GetData<Transform>("target");
        if (target == null)
        {
            state = NodeState.FAILURE;
            return state;
        }
        if (Vector3.Distance(_transform.position, target.position) <= _enemyConfig.attackRange)
        {
            Debug.Log(target);
            parent.parent.SetData<bool>("inCQC", true);
            state = NodeState.SUCCESS;
            return state;
        }
        state = NodeState.FAILURE;
        return state;
    }

}