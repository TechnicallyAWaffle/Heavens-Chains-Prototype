using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    AvarielMain currentState;

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter(null);
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    public void ChangeState(AvarielMain newState)
    {
        currentState.Exit();
        Debug.Log("Exiting: " + currentState.stateName + "/// Entering: " + newState.stateName);
        newState.Enter(currentState.stateName);
        currentState = newState;
    }

    protected virtual AvarielMain GetInitialState()
    {
        return null;
    }

    private void OnGUI()
    {
        string content = currentState != null ? currentState.stateName : "(no current state)";
        GUILayout.Label($"<color='white'><size=40>{content}</size></color>");
    }

}