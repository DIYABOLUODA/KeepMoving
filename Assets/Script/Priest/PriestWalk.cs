using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestWalk : IState
{
    Animator animator;
    PriestState priestState;
    Priest priest;
    public PriestWalk(Animator animator,PriestState priestState,Priest priest){
        this.animator = animator;
        this.priestState = priestState;
        this.priest = priest;
    }
    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void LogicUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void PhysicUpdate()
    {
        throw new System.NotImplementedException();
    }

    
}
