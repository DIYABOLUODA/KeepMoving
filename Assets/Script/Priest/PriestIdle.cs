using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestIdle : IState
{
    Animator animator;
    PriestState priestState;
    Priest priest;
    public PriestIdle(Animator animator,PriestState priestState,Priest priest){
        this.animator = animator;
        this.priestState = priestState;
        this.priest = priest;
    }

    public void Enter()
    {
       animator.Play("PriestIdle");

    }

    public void Exit()
    {
       // throw new System.NotImplementedException();
    }

    public void LogicUpdate()
    {
        if(priest.IsneedRecovers){
            priest.IsneedRecovers = false;
            priestState.changeState(priestState.priestRecovers);
        }
    }

    public void PhysicUpdate()
    {
       // throw new System.NotImplementedException();
    }

    // Start is called before the first fra
}
