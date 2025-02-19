
using UnityEngine;

public class SlimeHurt :IState
{
    
    private float stateStartTime;
    private bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    private float StateDuration => Time.time - stateStartTime;
     private SlimeState slimeState;
    private Animator animator;
    Slime slime;

    public SlimeHurt(SlimeState slimeState, Animator animator,Slime slime){
        this.slime = slime; 
        this.animator = animator;
        this.slimeState = slimeState;
    }
    public void Enter()
    {
        slime.StopMove();
        stateStartTime=Time.time;
        if(animator != null){
            animator.Play("SlimeHurt");
        }
    }


    public void LogicUpdate()
    {
        if(IsAnimationFinished){
            slime.IsHurt=false;
            if(slime.IsDeath){
                slimeState.ChangeState(slimeState.slimeDeath);
            }
            else if(slime.IsAttack){
                slimeState.ChangeState(slimeState.slimeAttack);
            }
            else if(slime.IsMove){
                slimeState.ChangeState(slimeState.slimeWalk);
            }
            else{
                slimeState.ChangeState(slimeState.slimeIdle);
            }
        }
    }

    public void PhysicUpdate()
    {
        
    }

    public void Exit()
    {
        
    }
}
