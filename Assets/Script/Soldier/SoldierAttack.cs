
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Attack", fileName = "SoldierAttack")]
public class SoldierAttack : PlayerState//�����ж��ܹ����ٹ����������궯�������˳���
{
    Soldier soldier;
   // BoxCollider2D box;
    public override void Enter()
    {
        //Debug.Log("solider'speed:" + soldier.currentXSpeed + "   \n" + soldier.YSpeed + "\n");    
        player.SetVelocity(0, 0);
        animator.Play("SoldierAttack");
        stateStartTime = Time.time;
        soldier = animator.GetComponent<Soldier>();
        soldier.Power-=soldier.returnAttPowerCount();  
        soldier.startInitalizePower();
        AudioManager.Instance.PlayRandomSFX(soldier.attackOne);
 
        
        
    }
    public override void LogicUpdate()
    {
        if (IsAnimationFinished)
        {
            soldier.IsAttack = false;
            stateMachine.SwitchState(typeof(SoldierMove));

                soldier.startPowerCorout();
        }
        else if(soldier.IsHurt){
            soldier.IsAttack = false;
            stateMachine.SwitchState(typeof(SoldierHurt));
            soldier.startPowerCorout();
        }
    }
  


}
