using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    IState currentState;

   protected Dictionary<System.Type, IState> stateTable;

    void Update()
    {
        currentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        currentState.PhysicUpdate();
    }
    protected void SwitchOn(IState newState)//´«ÈëÐÂµÄ×´Ì¬
    {
        currentState = newState;
        currentState.Enter();
    }
    public void SwitchState(IState newState)//ÇÐ»»×´Ì¬
    {
        currentState.Exit();
        SwitchOn(newState);
    }

    public void SwitchState(System.Type newStateType)//ÇÐ»»×´Ì¬
    {
        SwitchState(stateTable[newStateType]);
    }
}
