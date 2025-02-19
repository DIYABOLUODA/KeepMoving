using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Shoot",fileName ="SoldierShoot")]
public class SoldierShoot :PlayerState
{
    Soldier soldier;
   
    public override void Enter()
    {
        player.SetVelocity(0, 0);
        animator.Play("SoldierShoot");
        stateStartTime=Time.time;
        soldier=animator.GetComponent<Soldier>();
        soldier.Power-=soldier.returnShootPowerCount();
        soldier.startInitalizePower();
        if(AudioManager.Instance!=null)
        AudioManager.Instance.PlayRandomSFX(soldier.bow);
    }
    public override void LogicUpdate()
    {
        if(IsAnimationFinished||soldier.IsIdle){
            soldier.IsShoot=false;
            if(soldier.IsHurt){
                stateMachine.SwitchState(typeof(SoldierHurt));
            }
            else{
                stateMachine.SwitchState(typeof(SoldierMove));
            }

            soldier.startPowerCorout();
        }
    }
    public override void PhysicUpdate()
    {
    }
}
