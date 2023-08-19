using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskCommand : Node
{

	private Transform _transform;
    private string command;
    //Pass in as list of params in the future
    private float commandDuration = 5f;
    private MonoBehaviour monoBehaviour;
    private bool commandState = true;
    private EnemyConfig _enemyConfig;

    private float timer = 0f;
	
	public TaskCommand(Transform transform, EnemyConfig enemyConfig)
    {
        _transform = transform;
        _enemyConfig = enemyConfig;
    }

	public override NodeState Evaluate()
	{
		Transform target = GetData<Transform>("target");
        if (target != null)
        {
            if(GetData<bool>("canCommand") == true)
            {
                SetData<bool>("canCommand", false);
                command = "charge";
                commandDuration = 2.5f;
                foreach(BehaviorTreeBase squadMemberScript in _enemyConfig.squad)
                {
                    squadMemberScript.Command(command, commandState);
                }
                state = NodeState.SUCCESS;
                return state;
            }
            else 
            {
                timer += Time.deltaTime;
                if(timer >= commandDuration)
                {
                    commandState = !commandState;
                    SetData<bool>("canCommand", true);
                    timer = 0f;
                }
                else
                    state = NodeState.FAILURE;
                    return state;
            }
        }
        state = NodeState.FAILURE;
            return state;
	}
}