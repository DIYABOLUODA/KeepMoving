using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject,IState
{
   protected Animator animator;//���ж������л�
  protected  PlayerStateMachine stateMachine;//״̬���л�
    protected PlayerController player;
    protected PlayerInput input;
    protected float stateStartTime;
    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;
    protected float StateDuration => Time.time - stateStartTime;
    public void Initialize(Animator animator,PlayerStateMachine stateMachine,PlayerController player,PlayerInput input)//ʵ���Ͼ��Ƕ����״̬�ĳ�ʼ����
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
