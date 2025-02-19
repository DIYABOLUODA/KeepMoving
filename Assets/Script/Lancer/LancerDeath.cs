using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerDeath : IState
{
    Lancer lancer;
    LancerState lancerState;
    Animator animator;
    Rigidbody2D rb2;
    float stateStartTime;
    float stateDuration=>Time.time-stateStartTime;
    bool IsAnimationFinished=>stateDuration>=animator.GetCurrentAnimatorStateInfo(0).length;

    public LancerDeath(LancerState lancerState,Animator animator,Lancer lancer){
        this.lancer = lancer;
        this.animator = animator;
        this.lancerState = lancerState;
    }
    public void Enter()
    {
        rb2=lancer.GetComponent<Rigidbody2D>();
        rb2.velocity=new Vector2(0,0);
        Debug.Log("啊实打实");
       animator.Play("LancerDeath");
       stateStartTime=Time.time;
    }

    public void Exit()
    {
       
    }

    public void LogicUpdate()
    {
       if(IsAnimationFinished){
        lancer.gameObject.SetActive(false);
       }
    }

    public void PhysicUpdate()
    {
        
    }

}
