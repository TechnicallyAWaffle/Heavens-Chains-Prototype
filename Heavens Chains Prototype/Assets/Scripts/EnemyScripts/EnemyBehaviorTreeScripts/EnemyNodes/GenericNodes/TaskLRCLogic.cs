using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskLRCLogic: Node
{
    private Transform _transform;
    private Vector3 origin;
    private float radius = 10f;
    private Vector3 randomEnemyPosition;
    private float timer = 0f;
    private static float cooldown = 5f;
    private EnemyConfig _enemyConfig;

    public TaskLRCLogic(Transform transform, EnemyConfig enemyConfig)
    {
        _transform = transform;
        origin = _transform.position;
        _enemyConfig = enemyConfig;
    }

    public override NodeState Evaluate()
    {
        Transform target = GetData<Transform>("target");
        if (Vector3.Distance(_transform.position, target.position) > 2f)
        {
            int randomBehavior = Random.Range(1, 2);
            switch(randomBehavior)
            {
                case 1:
                    _transform.position = Vector3.MoveTowards(
                    _transform.position,
                    randomEnemyPosition,
                    _enemyConfig.hoverSpeed * Time.deltaTime);
                    timer += Time.deltaTime;
                    if(timer >= cooldown)
                        {
                            randomEnemyPosition = origin + Random.insideUnitSphere * radius;
                            cooldown = Random.Range(2f, 6f);
                            timer = 0f;
                        }
                    break;
                case 2:
                     _transform.position = Vector3.MoveTowards(
                    _transform.position,
                    target.position,
                    _enemyConfig.hoverSpeed * Time.deltaTime);
                    break;
            }
        }
        state = NodeState.RUNNING;
        return state;
    }
}