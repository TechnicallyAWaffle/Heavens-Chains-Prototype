using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingPlayerState : BaseState
{
    
    private MovementSM _sm;    

    public MovingPlayerState(MovementSM stateMachine) : base("Moving", stateMachine) {_sm = stateMachine;}
}