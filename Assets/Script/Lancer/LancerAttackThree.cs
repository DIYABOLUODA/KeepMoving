using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerAttackThree : IState
{
    LancerState lancerState;
    Animator animator;
    Lancer lancer;
    Vector2 targetPos;
    Rigidbody2D rb2;
    private int power=3;
    float startStateTime;
    float stateDuration=>Time.time - startStateTime;
    bool IsAnimationFinished=>stateDuration>=animator.GetCurrentAnimatorStateInfo(0).length;
    
   public LancerAttackThree(LancerState lancerState,Animator animator,Lancer lancer){
        this.lancerState=lancerState;
        this.animator=animator;
        this.lancer=lancer;
    }

    public void Enter()
    {
        rb2=lancer.GetComponent<Rigidbody2D>();
        rb2.velocity=new Vector2(0, 0);
     //   AttackThree();
        AttackThree();
        startStateTime=Time.time;
        animator.Play("LancerAttackThree");
      //  Debug.Log("哈哈，我进来咯");
      AudioManager.Instance.PlayRandomSFX(lancer.attackThreeSFX);
    }

    public void Exit()
    {
         lancer.IsEnableAttackThree = false;
        lancer.IsAttackThree = false;
        lancer.LancerPower-=power;
      //  Debug.Log("当前体力值"+lancer.LancerPower);
    //    Debug.Log("退出攻击3状态");
         lancer.SetRange();
    }

    public void LogicUpdate()
    {
       if(IsAnimationFinished){
        lancer.IsEnableAttackThree = false;
        lancer.IsAttackThree = false;

        lancerState.changeState(lancerState.lancerAttackIdle);
       }else if(lancer.IsHurt||lancer.IsDeath){
        lancer.IsEnableAttackThree = false;
        lancer.IsAttackThree = false;
        lancerState.changeState(lancerState.lancerHurt);
       }
    }

    public void PhysicUpdate()
    {
        BossMove(targetPos);
    }
    void AttackThree(){
            targetPos=((Vector2)lancer.Player.transform.position-rb2.position).normalized;
    }
    void BossMove(Vector2 moment){
        rb2.velocity=moment*lancer.setlancerSpeed();
    }

}
