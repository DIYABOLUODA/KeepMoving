
using UnityEngine;

public class SkeletonIdle : IState
{
    private Animator animator;
    private SkeletonState skeletonState;

    private Skeleton skeleton;
    public SkeletonIdle(SkeletonState skeletonState,Animator animator,Skeleton skeleton){
        this.skeletonState = skeletonState;
        this.animator = animator;
        this.skeleton = skeleton;
    }
    public void Enter()
    {   skeleton.StopMove();
        if(animator!=null){
        animator.Play("SkeletonIdle");
        }
    }

    public void Exit()
    {
        
    }

    public void LogicUpdate()
    {
        if(skeleton.IsHurt){
            skeletonState.changeState(skeletonState.skeletonHurt);
        }
        if(skeleton.IsAttack){
            skeletonState.changeState(skeletonState.skeletonAttackOne);
        }
        if(skeleton.IsMove){
            skeleton.IsIdle = false;
            skeletonState.changeState(skeletonState.skeletonWalk);
        }
    }

    public void PhysicUpdate()
    {
       
    }
}
