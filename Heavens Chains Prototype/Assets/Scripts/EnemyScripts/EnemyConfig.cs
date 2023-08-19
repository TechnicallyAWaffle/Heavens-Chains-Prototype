using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Note for self: In the future, you can tweak difficulty levels by making all enemy scripts use += and altering values in this class :OOO

using BehaviorTree;

public class EnemyConfig : MonoBehaviour
{
    public float speed = 0;
    public float hoverSpeed = 0;
    public float maxRadiance = 0;
    public float currentRadiance = 0;
    public float deathTimer = 0;
    public float revivalChance = 0;
    public float revivals = 0;
    public float effectiveRange = 0;
    public float attackRange = 0;
    public bool canCommand = true;
    public bool charge = true;
    //private GameObject buddy;
    public List<BehaviorTreeBase> squad;
    public int squadRank;
    public string enemyName;
}