
using System.Collections;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Death", fileName = "SoldierDeath")]
public class SoldierDeath : PlayerState
{
    public override void Enter()
    {
        player.SetVelocity(0,0);
        
        animator.Play("SoldierDeath");
        stateStartTime = Time.time;
       
    }
    public override void LogicUpdate()
    {
        if (IsAnimationFinished)
        {
            WaitChangeScene();
            animator.gameObject.SetActive(false);
        }
    }

    IEnumerator WaitChangeScene(){
        yield return 0.5f;
    }
}
