using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestRecovers : IState
{
    float stateStartTime;
    private bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    private float StateDuration => Time.time - stateStartTime;//现在的时间减去之前的时间

    Animator animator;
    PriestState priestState;

    Priest priest;

    public PriestRecovers(Animator animator,PriestState priestState,Priest priest){
        this.animator = animator;
        this.priestState = priestState;
        this.priest = priest;
    }
    public void Enter()
    {
      animator.Play("PriestRecovers");
       stateStartTime=Time.time;
    }

    public void Exit()
    {
      //  throw new System.NotImplementedException();
    }

    public void LogicUpdate()
    {
       if(IsAnimationFinished){
         priest.IsneedRecovers=false;
        priestState.changeState(priestState.priestIdle);
       }
    }

    public void PhysicUpdate()
    {
       // throw new System.NotImplementedException();
    }

    // Start is called before the first frame updat
}
