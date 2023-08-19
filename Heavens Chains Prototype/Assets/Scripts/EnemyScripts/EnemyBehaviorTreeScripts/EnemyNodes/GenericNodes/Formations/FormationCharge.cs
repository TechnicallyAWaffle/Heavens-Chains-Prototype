using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class FormationCharge : Node
{
	private bool commandInput;
	private Transform _transform;
	private EnemyConfig _enemyConfig;

	public FormationCharge(Transform transform, EnemyConfig enemyConfig)
    {
        _transform = transform;
		_enemyConfig = enemyConfig;
    }

	public override NodeState Evaluate()
	{
		Transform target = GetData<Transform>("target");
		commandInput = GetData<bool>("charge");
		if(commandInput == true && target != null)
		{
			_transform.position = Vector3.MoveTowards(
            _transform.position,
            target.position,
            _enemyConfig.speed * Time.deltaTime);
			state = NodeState.RUNNING;
			return state;
		}
		else
			state = NodeState.FAILURE;
			return state;
		
	}
}