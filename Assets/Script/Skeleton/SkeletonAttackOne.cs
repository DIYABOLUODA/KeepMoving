
using UnityEngine;

public class SkeletonAttackOne : IState
{
    float stateStartTime;
    private bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    private float StateDuration => Time.time - stateStartTime;//现在的时间减去之前的时间

    private Animator animator;
    private SkeletonState skeletonState;

    private Skeleton skeleton;
    public SkeletonAttackOne(SkeletonState skeletonState,Animator animator,Skeleton skeleton){
        this.skeletonState = skeletonState;
        this.animator = animator;
        this.skeleton = skeleton;
    }

    public void Enter()
    {
        
        stateStartTime = Time.time;
        skeleton.StopMove();
       if(animator!=null){
        animator.Play("SkeletonAttackOne");
       }
       AudioManager.Instance.PlayRandomSFX(skeleton.attack);
    }

    public void Exit()
    {
        
    }

    public void LogicUpdate()
    {
        if(IsAnimationFinished||skeleton.IsHurt){
            skeleton.IsAttack=false;
            if(skeleton.IsHurt){
                skeletonState.changeState(skeletonState.skeletonHurt);
            }
            else if(skeleton.IsMove){
                skeletonState.changeState(skeletonState.skeletonWalk);
            }else{
                skeletonState.changeState(skeletonState.skeletonIdle);
            }
        }
    }

    public void PhysicUpdate()
    {
        
    }
}
