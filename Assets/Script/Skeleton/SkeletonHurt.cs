using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonHurt : IState
{

    float stateStartTime;
    private bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    private float StateDuration => Time.time - stateStartTime;//现在的时间减去之前的时间

    private Animator animator;
    private SkeletonState skeletonState;

    private Skeleton skeleton;
    public SkeletonHurt(SkeletonState skeletonState,Animator animator,Skeleton skeleton){
        this.skeletonState = skeletonState;
        this.animator = animator;
        this.skeleton = skeleton;
    }
    public void Enter()
    {   skeleton.StopMove();
        stateStartTime = Time.time;
        if(animator!=null){
            animator.Play("SkeletonHurt");
        }
    }

    public void Exit()
    {
        
    }

    public void LogicUpdate()
    {
       if(IsAnimationFinished){
            skeleton.IsHurt=false;
            if(skeleton.IsDeath){
                skeletonState.changeState(skeletonState.skeletonDeath);
            }else if(skeleton.IsAttack){//攻击有两段，所以这里需要改，可能要用到行为树；
                skeletonState.changeState(skeletonState.skeletonAttackOne);
            }else{
                skeletonState.changeState(skeletonState.skeletonIdle);
            }
       }
    }

    public void PhysicUpdate()
    {

    }
}
