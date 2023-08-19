using System.Collections.Generic;
using System.Collections;
using BehaviorTree;
using UnityEngine;
using UnityEngine.InputSystem;

public class GuardianAngelBT: BehaviorTreeBase, IEnemyBTReference
{
private Rigidbody2D rb;
    private Transform ts;

    public InputAction playerControls;
    Animator animator;
    CapsuleCollider2D enemyCollider;
    public SpriteRenderer spriteRenderer;
    public AttackManager attackManager;
    public BehaviorTreeBase behaviorTreeBase;
    public GameObject guardianAngelWings;
    public EnemyConfig enemyConfig;
    
    public Vector2 movement;
    Vector2 moveDirection = Vector2.zero;

    public bool IsAttacking = false;
    public bool flipped = false;
    [SerializeField] List<GameObject> enemyWeapons;

    private GameObject activeWeapon;
    private Node root;

    public void ConfigureEnemy(string name, ref List<BehaviorTreeBase> squad, int squadRank)
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        enemyCollider = gameObject.GetComponent<CapsuleCollider2D>();
        attackManager = gameObject.GetComponent<AttackManager>();
        enemyConfig = transform.gameObject.AddComponent<EnemyConfig>();
        //activeWeapon = enemyWeapons[0];
        enemyConfig.speed = 6f;
        enemyConfig.hoverSpeed = 1.5f;
        enemyConfig.maxRadiance = 100f;
        enemyConfig.effectiveRange = 12f;
        enemyConfig.currentRadiance = 100f;
        enemyConfig.deathTimer = 3f;
        enemyConfig.revivalChance = 0.10f;
        enemyConfig.revivals = 0.1f;
        enemyConfig.enemyName = name;
        enemyConfig.squad = squad;
        enemyConfig.squadRank = squadRank;
        enemyConfig.attackRange = 1f;
        enemyConfig.canCommand = false;
        enemyConfig.charge = false;
        _root = SetupTree();
    }

    public float CurrentRadiance
    {
        get {return enemyConfig.currentRadiance;}
        set {enemyConfig.currentRadiance = value;}
    }

    public float MaxRadiance
    {
        get {return enemyConfig.maxRadiance;}
        set {enemyConfig.maxRadiance = value;}
    }

    public float Revivals
    {
        get {return enemyConfig.revivals;}
        set {enemyConfig.revivals = value;}
    }
 
    public float RevivalChance
    {
        get {return enemyConfig.revivalChance;}
        set {enemyConfig.revivalChance = value;}
    }

    public void OnEnemyPrimaryAttackEnd(string message)
    {
        //Hardcoded, will have to reference current equipped weapon instead
        //gameObject.GetComponentInChildren<SpearCollision>().SpearAttackEnd();
    }

    public void UpdateEnemyMaxRadiance(float value)
    {
        //we don't really need this method for now
    }

    public void UpdateEnemyCurrentRadiance(float value)
    {
        enemyConfig.currentRadiance += value;
        animator.SetBool("Hit", true);
        animator.SetTrigger("HitTrigger");
        Debug.Log("Enemy Radiance Drained, " + CurrentRadiance + "/" + MaxRadiance);
        if (CurrentRadiance <= 0)
        {
            animator.SetBool("Death", true);
            StartCoroutine(DeathCycle());
        }
    }

    public void EnemyRevive()
    {
        Revivals += 0.1f;
        gameObject.GetComponent<Animator>().SetBool("Death", false);
        guardianAngelWings.SetActive(true);
        CurrentRadiance = MaxRadiance;
        //hardcoded for now, later will wrap in state machine
        rb.gravityScale = 0;
        RevivalChance = 0.85f;
        SetupTree();
    }

    public void EnemyDie()
    {
        //play corpse destruction
        Object.Destroy(gameObject);
    }

    IEnumerator DeathCycle()
    {
        _root = null;
        //hardcoded for now, later will wrap in state machine
        rb.gravityScale = 2;
        guardianAngelWings.SetActive(false);
        yield return new WaitForSeconds(enemyConfig.deathTimer);
        if (Random.Range(0.00f, 1f) <= RevivalChance + Revivals) EnemyRevive();
        else EnemyDie();
    }

    public void HitAnimationEnd()
    {
        animator.SetBool("Hit", false);
    }

    public void DeathAnimationEnd()
    {
        animator.SetTrigger("DieLoop");
    }

    public override void Command(string command, bool commandState)
    {   
        root.SetData<bool>(command, commandState);
    }

    protected override Node SetupTree()
    { 
        if(enemyConfig.squadRank != 1)
        {
            root = new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new TaskCQCLogic(transform, enemyConfig),
                    new TaskAttack(attackManager, activeWeapon),
                    //Step back based on formation
                    //Go towards squad members and hover within a current range of them
                }),
                new Sequence(new List<Node>
                {
                    new FormationCharge(transform, enemyConfig),
                }),
                new Sequence(new List<Node>
                {
                    new TaskDetectPlayer(transform, enemyConfig),
                    new TaskLRCLogic(transform, enemyConfig),
                    //Dash to player if charging
                    //Glide to player in formation?!?!?!
                }),
                new TaskIdle(),
            });
            root.SetData<bool>("canFreeAct", true);
            return root;
        }
        else
        {
            root = new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new TaskCQCLogic(transform, enemyConfig),
                    new TaskAttack(attackManager, activeWeapon),
                    //Step back based on formation
                    //Go towards squad members and hover within a current range of them
                }),
                new Sequence(new List<Node>
                {
                    //Command lower ranked angels instead of defaulting to indepndent behavior
                    new TaskCommand(transform, enemyConfig),
                }),
                new Sequence(new List<Node>
                {
                    new TaskDetectPlayer(transform, enemyConfig),
                    new TaskLRCLogic(transform, enemyConfig),
                }),
                new TaskIdle(),
            });
            root.SetData<bool>("canCommand", true);
            return root;
        }
    }
}