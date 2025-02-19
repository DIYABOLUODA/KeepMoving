
using UnityEngine;

public class SlimeDeath : IState
{
    private float stateStartTime;
    private bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    private float StateDuration => Time.time - stateStartTime;


    private SlimeState slimeState;
    private Animator animator;
    Slime slime;



    public SlimeDeath(SlimeState slimeState, Animator animator,Slime slime){
        this.slimeState = slimeState;
        this.animator = animator;
        this.slime = slime;
    }

    public void Enter()
    {
        ScoreManager.Instance.AddCount(slime.countPoint);
        stateStartTime=Time.time;
        if (animator != null){
            animator.Play("SlimeDeath");
        }
    }

    public void Exit()
    {
        
    }

    public void LogicUpdate()
    {
        if(IsAnimationFinished){
            slime.IsDeath = false;
            slime.gameObject.SetActive(false);
        }
    }

    public void PhysicUpdate()
    {
        
    }
}
