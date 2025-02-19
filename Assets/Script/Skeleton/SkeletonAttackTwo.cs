using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackTwo : IState
{
    float stateStartTime;
    private bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    private float StateDuration => Time.time - stateStartTime;//现在的时间减去之前的时间

    private Animator animator;
    private SkeletonState skeletonState;

    private Skeleton skeleton;
    public SkeletonAttackTwo(SkeletonState skeletonState,Animator animator,Skeleton skeleton){
        this.skeletonState = skeletonState;
        this.animator = animator;
        this.skeleton = skeleton;
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
