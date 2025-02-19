using System.Collections;
using UnityEngine;
[CreateAssetMenu(menuName ="Data/StateMachine/PlayerState/Move",fileName ="SoldierMove")]
public class SoldierMove : PlayerState
{
    private Soldier soldier;
  //  private Coroutine slowDownCoroutine;
    //private Coroutine restoreSpeedCoroutine;
   // private MonoBehaviour coroutineRunner;
  // private float AnimatorSpeed;
    public override void Enter()
    {

       // Debug.Log("solider'speed:" + soldier.currentXSpeed+"   \n"+soldier.YSpeed+"\n");
       // stateStartTime = Time.time;
        animator.Play("SoldierMove");
     //   AnimatorSpeed = animator.speed;
       soldier = animator.GetComponent<Soldier>();
       // coroutineRunner = animator.GetComponent<MonoBehaviour>();
    }
    public override void LogicUpdate()//还要改一下，以后再改，有时候他不会回弹；当速度不是最大值时要慢慢加速；
    {//而且这个东西是一定要减到特定值，所以有问题

        if (soldier.IsHurt)
        {
            stateMachine.SwitchState(typeof(SoldierHurt));
          //  coroutineRunner.StopAllCoroutines();
          //  return;
        }
        if(soldier.IsIdle){
          soldier.IsMove=false;
          stateMachine.SwitchState(typeof(SoldierIdle));
        }

//这里改的是攻击1
  //      if (soldier.IsAttack)//稍微改了一下，主要这个圆检测器太拉了，我以后改成射线
  //      {
  //          if(soldier.EnableAttack)
  //          stateMachine.SwitchState(typeof(SoldierAttack));
  //          else{
  //              soldier.IsAttack=false;
  //          }
       //     coroutineRunner.StopAllCoroutines();
  //      }


        if(input.shoot){
            if(soldier.Power>=soldier.returnShootPowerCount()){
            soldier.IsShoot=true;
            stateMachine.SwitchState(typeof(SoldierShoot));
            }
        }
        if(input.attack){
            if(soldier.Power>=soldier.returnAttPowerCount()){
            soldier.IsAttack=true;
            stateMachine.SwitchState(typeof(SoldierAttack));
            }
        }
        if(input.attckTwo){
                if(soldier.Power>=soldier.returnAttTwoPowerCount()){
                    soldier.IsAttackTwo=true;
            stateMachine.SwitchState(typeof(SoldierAttackTwo));
                }
        }

//     //这段是用协程写的玩意
//    if (restoreSpeedCoroutine != null)
//  
//    {
//        coroutineRunner.StopCoroutine(restoreSpeedCoroutine);
//        restoreSpeedCoroutine = null;
//    }
//    if (slowDownCoroutine == null)
//    {
//        slowDownCoroutine = coroutineRunner.StartCoroutine(SlowDown());
//    }
//}
//else
//{
//    if (restoreSpeedCoroutine == null)
//    {
//        restoreSpeedCoroutine = coroutineRunner.StartCoroutine(RestoreSpeed());
//    }
//    if (slowDownCoroutine != null)
//    {
//        coroutineRunner.StopCoroutine(slowDownCoroutine);
//        slowDownCoroutine = null;
//    }




//    if (input.shoot) {
//     soldier.currentXSpeed-=Time.fixedDeltaTime*soldier.SlowDownPower;
//    }else
//    {
//        soldier.currentXSpeed+=Time.fixedDeltaTime*soldier.SlowDownPower;//改
//    }
//        if(soldier.IsIdle){
//            stateMachine.SwitchState(typeof(SoldierIdle));
//        }
   }



 // private IEnumerator SlowDown()
 //      {
 //      
 //      float timer = 0f;

 //      while (timer < soldier.slowDownDuration)
 //      {
 //          soldier.currentXSpeed = Mathf.Lerp(soldier.MaxXSpeed, soldier.MinXSpeed, timer / soldier.slowDownDuration);//第三个参数返回插值result=a+(b−a)×t；
 //          float newSpeed = Mathf.Lerp(AnimatorSpeed, AnimatorSpeed * soldier.slowDownFactor, timer / soldier.slowDownDuration);
 //          animator.SetFloat("MoveSpeed", newSpeed);
 //          timer += Time.deltaTime;
 //          yield return null;
 //      }


 //      soldier.currentXSpeed = soldier.MinXSpeed;
 //      animator.SetFloat("MoveSpeed", AnimatorSpeed * soldier.slowDownFactor);
 //  }
 //  private IEnumerator RestoreSpeed()
 //  {
 //      float timer = 0f;
 //      while (timer < soldier.slowDownDuration && soldier.currentXSpeed < soldier.MaxXSpeed)
 //      {
 //          soldier.currentXSpeed = Mathf.Lerp(soldier.MinXSpeed, soldier.MaxXSpeed, timer / soldier.slowDownDuration);//第三个参数返回插值result=a+(b−a)×t；
 //          float newSpeed = Mathf.Lerp(AnimatorSpeed * soldier.slowDownFactor, AnimatorSpeed, timer / soldier.slowDownDuration);
 //          animator.SetFloat("MoveSpeed", newSpeed);
 //          timer += Time.deltaTime;
 //          yield return null;
 //      }
 //      soldier.currentXSpeed = soldier.MaxXSpeed;
 //      animator.SetFloat("MoveSpeed", AnimatorSpeed * soldier.slowDownFactor);
 //  }

    public override void PhysicUpdate()
    {
        player.SetVelocity(soldier.currentXSpeed * Time.fixedDeltaTime, soldier.YSpeed*input.AxisY*Time.fixedDeltaTime);
    }
}
