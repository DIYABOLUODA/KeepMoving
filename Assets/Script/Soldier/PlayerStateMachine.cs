
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine :StateMachine
{
   
    Animator animator;
    PlayerController player;
    PlayerInput input;
    [SerializeField] PlayerState[] states;
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        player = GetComponent<PlayerController>();
        stateTable = new Dictionary<System.Type, IState>(states.Length);
        animator = GetComponent<Animator>();

        foreach(PlayerState state in states)
        {
            state.Initialize(animator,this,player,input);
            stateTable.Add(state.GetType(), state);
        }
    }
    private void Start()
    {
        SwitchOn(stateTable[typeof(SoldierMove)]);
    }
}
