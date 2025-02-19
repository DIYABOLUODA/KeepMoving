using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerAttackTwo : IState
{

 LancerState lancerState;
    Animator animator;
    Lancer lancer;

   Rigidbody2D rb2;

       private int power=2;
    float startStateTime;
    float stateDuration=>Time.time - startStateTime;
    bool IsAnimationFinished=>stateDuration>=animator.GetCurrentAnimatorStateInfo(0).length;
    
   public LancerAttackTwo(LancerState lancerState,Animator animator,Lancer lancer){
        this.lancerState=lancerState;
        this.animator=animator;
        this.lancer=lancer;
    }

    public void Enter()
    {
      rb2=lancer.GetComponent<Rigidbody2D>();
      rb2.velocity = new Vector2(0, 0);
   //   AttackTwo();
      animator.Play("LancerAttackTwo");
      startStateTime=Time.time;
      AudioManager.Instance.PlayRandomSFX(lancer.attackTwoSFX);
    }

    public void Exit()
    {
     // Debug.Log("退出攻击2状态");
       lancer.LancerPower-=power;
     //    Debug.Log("当前体力值"+lancer.LancerPower);
      lancer.SetRange();
    }

    public void LogicUpdate()
    {
        
        if(IsAnimationFinished){
        lancer.IsEnableAttackTwo = false;
        lancer.IsAttackTwo = false;
        lancerState.changeState(lancerState.lancerAttackIdle);
       }else if(lancer.IsHurt||lancer.IsDeath){
        lancer.IsEnableAttackTwo= false;
        lancer.IsAttackTwo = false;
        lancerState.changeState(lancerState.lancerHurt);
       }
    }

    public void PhysicUpdate()
    {
       //AttacOne();
  //   BossMove(targetPos);
    }

}
