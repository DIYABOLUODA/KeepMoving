using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonWalk : IState
{
    SkeletonState skeletonState;
    Animator animator;
    Skeleton skeleton;
    public SkeletonWalk(SkeletonState skeletonState,Animator animator,Skeleton skeleton ){
        this.skeletonState = skeletonState;
        this.animator = animator;
        this.skeleton = skeleton;
    }
    public void Enter()
    {
        if(animator!=null){
       animator.Play("SkeletonWalk");
        }
    }

    public void Exit()
    {
        
    }

    public void LogicUpdate()
    {
        if(skeleton.IsAttack){
            skeleton.IsMove=false;
            skeletonState.changeState(skeletonState.skeletonAttackOne);
        }else if(skeleton.IsHurt){
            skeleton.IsMove=false;
            skeletonState.changeState(skeletonState.skeletonHurt);
        }
        else if(skeleton.IsIdle){
            skeleton.IsMove=false;
            skeletonState.changeState(skeletonState.skeletonIdle);
        }

        
       
    }

    public void PhysicUpdate()
    {
       
    }
}
