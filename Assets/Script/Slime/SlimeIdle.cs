using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIdle : IState
{
    private SlimeState slimeState;
    private Animator animator;
    Slime slime;
    public SlimeIdle(SlimeState slimeState,Animator animator,Slime slime){
        this.slimeState=slimeState;
        this.animator=animator;
        this.slime=slime;
    }
    public void Enter()
    {
        slime.StopMove();
        if(animator!=null){
        animator.Play("SlimeIdle");
        }
    }

    public void Exit()
    {
       // throw new System.NotImplementedException();
    }

    public void LogicUpdate()
    {
        if(slime.IsHurt){
            slimeState.ChangeState(slimeState.slimeHurt);
        }
        if(slime.IsAttack){
            slimeState.ChangeState(slimeState.slimeAttack);
        }
        if(slime.IsMove){
            slime.IsIdle = false;
            slimeState.ChangeState(slimeState.slimeWalk);
        }
    }

    public void PhysicUpdate()
    {
       // throw new System.NotImplementedException();
    }
}
