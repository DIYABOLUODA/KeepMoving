
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Hurt", fileName = "SoldierHurt")]
public class SoldierHurt : PlayerState//��ײ����������ʧ�Ȼ�����һ�ξ���
{
    Soldier soldier;

    public override void Enter()
    {
        player.SetVelocity(0,0);
        stateStartTime = Time.time;
        animator.Play("SoldierHurt");
        soldier = animator.GetComponent<Soldier>();
    }
    public override void LogicUpdate()
    {
        if (IsAnimationFinished)
        {
            soldier.IsHurt = false;
         if (soldier.IsDeath)
            {
                stateMachine.SwitchState(typeof(SoldierDeath));
            }
            else
                stateMachine.SwitchState(typeof(SoldierMove));
        }
    }

}
