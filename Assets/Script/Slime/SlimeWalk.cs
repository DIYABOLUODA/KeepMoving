using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeWalk : IState
{
    SlimeState slimeState;
    Animator animator;
    Slime slime;
    public SlimeWalk(SlimeState slimeState,Animator animator,Slime slime){
        this.slime = slime;
        this.animator = animator;
        this.slimeState=slimeState;
    }
    public void Enter()
    {
        animator.Play("SlimeWalk");
    }

    public void Exit()
    {
       
    }

    public void LogicUpdate()
    {
        if(slime.IsAttack){
            slime.IsMove = false;
            slimeState.ChangeState(slimeState.slimeAttack);
        }else if(slime.IsHurt){
            slime.IsMove=false;
            slimeState.ChangeState(slimeState.slimeHurt);
        }else if(slime.IsIdle){
            slime.IsMove=false;
            slimeState.ChangeState(slimeState.slimeIdle);
        }
    }

    public void PhysicUpdate()
    {
    }
}
