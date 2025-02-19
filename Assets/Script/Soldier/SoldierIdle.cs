using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Idle",fileName ="SoldierIdle")]
public class SoldierIdle :PlayerState
{
    Soldier soldier;
    public override void Enter()
    {
       player.SetVelocity(0, 0);
       animator.Play("SoldierIdle");
        soldier= animator.GetComponent<Soldier>();
    }
    public override void LogicUpdate()
    {
        if(soldier.IsMove){
         //   soldier.IsMove=false;
            soldier.IsIdle=false;
            stateMachine.SwitchState(typeof(SoldierMove));
        }
    }
    public override void PhysicUpdate()
    {
       
    }
    public override void Exit(){
        
    }
}
