using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseState
{
     

    public string name;

    protected Vector2 input;
    protected AvarielMain avarielMain;
    public string stateName;
    protected StateMachine stateMachine;

    public BaseState(string name, StateMachine stateMachine, AvarielMain avarielMain)
    {
        this.name = name;
        this.stateMachine = stateMachine;
        this.avarielMain = avarielMain;
    }

    public virtual void Enter(string previousState) {}
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
}