using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseState
{
    public string name;
    protected StateMachine stateMachine;
    public InputAction moveAction;
    public InputAction fallAction;

    protected Vector2 input;
    protected Rigidbody2D rb;

    public BaseState(string name, StateMachine stateMachine, AvarielMain avarielMain)
    {
        this.name = name;
        this.stateMachine = stateMachine;

        rb = avarielMain.gameObject.GetComponent<Rigidbody2D>();
        moveAction = avarielMain.playerInput.actions["Move"];
        fallAction = avarielMain.playerInput.actions["Fall"];
    }

    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}