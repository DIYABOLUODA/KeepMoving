using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerIdle : IState
{
    LancerState lancerState;
    Animator animator;
    Lancer lancer;
    Coroutine coroutine;
   

    Rigidbody2D rb2;
    float startStateTime;
    float stateDuration => Time.time - startStateTime;
    bool IsAnimationFinished => stateDuration >= lancer.Duration;

    public LancerIdle(LancerState lancerState ,Animator animator,Lancer lancer){
            this.lancerState=lancerState;
            this.animator=animator;
            this.lancer=lancer;
    }
    public void Enter()
    {
        lancer.tired.SetActive(true);
        lancer.IsIdle = true;
        rb2=lancer.GetComponent<Rigidbody2D>();
         rb2.isKinematic = true;
        rb2.velocity = new Vector2 (0, 0);
        lancer.LancerTrigger.layer=LayerMask.NameToLayer("Boss");
       animator.Play("LancerIdle");
       startStateTime=Time.time;

    }

    public void Exit()
    {
        lancer.tired.SetActive(false);
         rb2.isKinematic = false;
         lancer.LancerTrigger.layer=LayerMask.NameToLayer("BossAttack");
        if (coroutine != null)
        {
            lancer.StopCoroutine(coroutine);
            coroutine = null;
        }
        lancer.LancerPower=10;
        lancer.TakeDamageCount+=2;
       lancer.Duration-=0.25f;
    }

    public void LogicUpdate()
    {
        if(IsAnimationFinished){
            lancer.IsIdle=false;

            if(lancer.IsDeath){
                lancerState.changeState(lancerState.lancerHurt);
            }else{
            lancerState.changeState(lancerState.lancerWalkIdle);
            }
        }
    }

    public void PhysicUpdate()
    {
        
    }

   
}
