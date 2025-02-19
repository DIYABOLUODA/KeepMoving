
using UnityEngine;

public class SlimeAttack : IState
{
     private float stateStartTime;
    private bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    private float StateDuration => Time.time - stateStartTime;
    private SlimeState slimeState;
    private Animator animator;
    private Slime slime;
    public SlimeAttack(SlimeState slimeState,Animator animator,Slime slime){
        this.slimeState=slimeState;
        this.animator=animator;
        this.slime=slime;
    }
    public void Enter()
    {
        stateStartTime=Time.time;
       // Debug.Log("我打你了阿！");
        if(animator!=null){
        animator.Play("SlimeAttack");
        }
         AudioManager.Instance.PlayRandomSFX(slime.attack);
}

    public void Exit()
    {
        
    }

    public void LogicUpdate()
    {
        if(IsAnimationFinished||slime.IsHurt){
            slime.IsAttack=false;
            if(slime.IsHurt){
                slimeState.ChangeState(slimeState.slimeHurt);
            }
            else
            {
            slimeState.ChangeState(slimeState.slimeIdle);
            }
        }
    }

    public void PhysicUpdate()
    {
       // throw new System.NotImplementedException();
    }
}
