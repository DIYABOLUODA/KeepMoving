using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/AttackTwo",fileName ="SoldierAttackTwo")]
public class SoldierAttackTwo : PlayerState
{
    Soldier soldier;
    BoxCollider2D boxCollider2D;
    Coroutine coroutine;
    public override void Enter()//还需要一个往前移动的好东西
    {
        soldier=animator.GetComponent<Soldier>();
        boxCollider2D=animator.GetComponent<BoxCollider2D>();
        animator.Play("SoldierAttackTwo");
        stateStartTime=Time.time;
      //  boxCollider2D.enabled=false;
      AudioManager.Instance.PlayRandomSFX(soldier.attackTwo);
        soldier.Power-=soldier.returnAttTwoPowerCount();
        soldier.startInitalizePower();
      if(coroutine!=null){
        soldier.StopCoroutine(coroutine);
        coroutine=null;
      }
      coroutine=soldier.StartCoroutine(invincible());
    }
    public override void LogicUpdate()
    {
      if(IsAnimationFinished){
            soldier.IsAttackTwo=false;
            boxCollider2D.enabled = true;
            stateMachine.SwitchState(typeof(SoldierMove));
            soldier.startPowerCorout();
      }else if(soldier.IsHurt){
        soldier.IsAttackTwo=false;
        boxCollider2D.enabled=true;
        stateMachine.SwitchState(typeof(SoldierHurt));
        soldier.startPowerCorout();
      }
    }

    public override void PhysicUpdate()
    {
       // base.PhysicUpdate();
         player.SetVelocity(soldier.currentXSpeed * Time.fixedDeltaTime*1.5f,soldier.YSpeed*input.AxisY*Time.fixedDeltaTime);
    }

    public override void Exit()
    {
       // base.Exit();
        if(coroutine!=null){
        soldier.StopCoroutine(coroutine);
        coroutine=null;
      }

    }
    IEnumerator invincible(){
    //  Debug.Log("无敌时间");
      float time=0.15f;
      boxCollider2D.enabled=false;
      while(time>0){
        yield return new WaitForFixedUpdate();
      }
    //  Debug.Log("无敌时间结束");
      boxCollider2D.enabled=true;
    }
}
