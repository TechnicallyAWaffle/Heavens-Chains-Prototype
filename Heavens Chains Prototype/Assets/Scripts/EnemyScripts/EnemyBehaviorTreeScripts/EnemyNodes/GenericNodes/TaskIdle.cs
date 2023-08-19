using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class TaskIdle : Node
{

    //Add in a constructor sometime later    

    public override NodeState Evaluate()
    {   
        //Debug.Log("YIPEEEEEEE");
        state = NodeState.RUNNING;
        return state;
    }
}