using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDeath :IState
{
    float stateStartTime;
    private bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    private float StateDuration => Time.time - stateStartTime;//现在的时间减去之前的时间

    private Animator animator;
    private SkeletonState skeletonState;

    private Skeleton skeleton;
    public SkeletonDeath(SkeletonState skeletonState,Animator animator,Skeleton skeleton){
        this.skeletonState = skeletonState;
        this.animator = animator;
        this.skeleton = skeleton;
    }

    public void Enter()
    {   ScoreManager.Instance.AddCount(skeleton.countPoint);
        stateStartTime=Time.time;
        if(animator!=null){
            animator.Play("SkeletonDeath");
        }
    }

    public void Exit()
    {
        
    }

    public void LogicUpdate()
    {
        if(IsAnimationFinished){
            skeleton.IsDeath = false;
            skeleton.gameObject.SetActive(false);
        }
    }

    public void PhysicUpdate()
    {
       
    }
}
