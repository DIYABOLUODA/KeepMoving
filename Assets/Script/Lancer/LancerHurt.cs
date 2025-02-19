using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerHurt : IState
{

    LancerState lancerState;
    Animator animator;
    Lancer lancer;
    Vector2 targetPos;
   Rigidbody2D rb2;
    float stateStartTime;
    float stateDuration=>Time.time-stateStartTime;
    bool IsAnimationFinished=>stateDuration>=animator.GetCurrentAnimatorStateInfo(0).length;
   public LancerHurt(LancerState lancerState,Animator animator,Lancer lancer){
        this.lancerState=lancerState;
        this.animator=animator;
        this.lancer=lancer;
    }
    public void Enter()
    {
      EventManager.Instance.IsBossIdle();
       rb2=lancer.GetComponent<Rigidbody2D>();
       animator.Play("LancerHurt");
       stateStartTime=Time.time;
      ThelancerHurt();
      lancer.gameObject.layer=LayerMask.NameToLayer("BossAttack");
      AudioManager.Instance.PlayRandomSFX(lancer.hurtSFX);
    }

    public void Exit()
    {
           lancer.gameObject.layer=LayerMask.NameToLayer("Boss");
    }

    public void LogicUpdate()
    {
       if(IsAnimationFinished){
            lancer.setIsHurt(false);
            if(lancer.IsDeath){
               lancerState.changeState(lancerState.lancerDeath);
            }else{
          lancerState.changeState(lancerState.lancerIdle);
            }
            
       }
    }

    public void PhysicUpdate()
    {
       
    }

    void ThelancerHurt(){
     float distance =Vector2.Distance(lancer.transform.position,lancer.Player.transform.position);
         if(distance>4f){
            BossMove(lancer.setlancerAttackSpeed()*1.2f);
         }
         else{
           BossMove(lancer.setlancerSpeed()*2.5f);
         }
    }
   void BossMove(float speed){
      rb2.velocity=Vector2.right*speed;
   }
   
}
