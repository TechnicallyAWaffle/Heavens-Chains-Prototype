using System.Collections.Generic;
using System.Collections;
using UnityEngine;

using BehaviorTree;

public class TaskDetectPlayer : Node
{
    private Transform _transform;
    private static int _entityLayerMask = 1 << 7; 
    private EnemyConfig _enemyConfig;

    public TaskDetectPlayer(Transform transform, EnemyConfig enemyConfig)
    {
        _transform = transform;
        _enemyConfig = enemyConfig;
    }

    public override NodeState Evaluate()
    {
        //Debug.Log("hello?!?!?!!?");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_transform.position, _enemyConfig.effectiveRange, _entityLayerMask);
            if (colliders.Length > 0)
            {
                foreach(Collider2D entity in colliders)
                {
                    if(entity.gameObject.name == "Avariel")
                    { 
                        if(entity.transform.position.x > _transform.position.x) _transform.localScale = new Vector3(-1, 1, 1);
                        else _transform.localScale = new Vector3(1, 1, 1);
                        parent.parent.SetData<Transform>("target", entity.transform);
                        state = NodeState.SUCCESS;
                        return state;
                    }
                }
                ClearData("target");
                state = NodeState.FAILURE;
                return state;
            }
            state = NodeState.FAILURE;
            return state;
    }
}