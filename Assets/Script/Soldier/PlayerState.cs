using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject,IState
{
   protected Animator animator;//进行动画的切换
  protected  PlayerStateMachine stateMachine;//状态的切换
    protected PlayerController player;
    protected PlayerInput input;
    protected float stateStartTime;
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    protected float StateDuration => Time.time - stateStartTime;
    public void Initialize(Animator animator,PlayerStateMachine stateMachine,PlayerController player,PlayerInput input)//实际上就是对这个状态的初始化；
    {
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.player = player;
        this.input = input;
    }

    public virtual void Enter()
    {
        
    }

    public virtual void Exit()
    {
       
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
