/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseState
{
    public string name;
    protected StateMachine stateMachine;
    public InputAction moveAction;
    public InputAction fallAction;
    public InputAction dashAction;
    public InputAction glideAction;

    protected Vector2 input;
    protected Rigidbody2D rb;

    public BaseState(string name, StateMachine stateMachine, AvarielMain avarielMain)
    {
        this.name = name;
        this.stateMachine = stateMachine;

        rb = avarielMain.gameObject.GetComponent<Rigidbody2D>();
        moveAction = avarielMain.playerActions.movement;
        fallAction = avarielMain.playerActions.fall;
        dashAction = avarielMain.playerActions.dash;
        glideAction = avarielMain.playerActions.glide;
    }

    public virtual void Enter(string previousState) {}
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}
*/