using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public interface IEnemyBTReference
{
	void ConfigureEnemy(string name, ref List<BehaviorTreeBase> squad, int squadrank);
	void UpdateEnemyMaxRadiance(float value);
	void UpdateEnemyCurrentRadiance(float value);
	void EnemyRevive();
	void EnemyDie();
	void Command(string command, bool commandState);
}
