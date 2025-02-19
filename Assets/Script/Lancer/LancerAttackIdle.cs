using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerAttackIdle : IState
{
    LancerState lancerState;
    Animator animator;
    Lancer lancer;
    Rigidbody2D rb2;
    public float radius = 5f;
    public float arcAngle = 60f;
    private Vector2 targetPos;

    Vector2 attackOneTarget;
    Vector2 attackTwoTarget;
    Vector2 attackThreeTarget;
    Vector2 hitTarget;
    Coroutine coroutine;
    

    public LancerAttackIdle(LancerState lancerState, Animator animator, Lancer lancer)
    {
        this.lancerState = lancerState;
        this.animator = animator;
        this.lancer = lancer;
    }

    public void Enter()
    {
        lancer.SetRange();
       rb2=lancer.GetComponent<Rigidbody2D>();
        SetNewTargetPosition();

        if (coroutine != null)
        {
            lancer.StopCoroutine(coroutine);
            coroutine = null;
        }
        coroutine = lancer.StartCoroutine(AttackPlayerForDuration(1.8f));
        animator.Play("LancerAttackIdle");
    }

    public void Exit()
    {
        if (coroutine != null)
        {
            lancer.StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    public void LogicUpdate()
    {
        if(lancer.IsMove){
            lancer.IsAttack = false;
         //   Debug.Log("进入WalkIdle模式");
            lancerState.changeState(lancerState.lancerWalkIdle);
        }else if(lancer.IsHurt||lancer.IsDeath){
            lancer.IsAttack=false;
            lancerState.changeState(lancerState.lancerHurt);
        }
        else if (lancer.IsAttackOne)
        {
            MoveBossAttackOne();
        }
        else if (lancer.IsAttackTwo)
        {
           MoveBossAttackTwo();
        }
        else if (lancer.IsAttackThree)
        {
            MoveBossAttackThree();
        }

    }

    public void PhysicUpdate()
    {
        lancer.transform.localScale = lancer.Player.transform.position.x > lancer.transform.position.x ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
        if (!lancer.IsAttackOne && !lancer.IsAttackTwo && !lancer.IsAttackThree)
        {
            MoveBoss();
        }

        if (lancer.IsAttack && lancer.LancerPower == 0)
        {
         //   lancer.IsAttack = false;
         //   lancer.ChooseAttackMode();
         lancer.IsMove = true;
        }
    }

    private bool IsNotInObstacle(Vector3 pos)
    {
        return Physics2D.OverlapCircle(pos, 0.1f) == null;
    }

    void SetNewTargetPosition()
    {
        Vector2 newPos;
    do
    {
        float angle = Random.Range(-arcAngle / 2, arcAngle / 2);
        float angleRad = angle * Mathf.Deg2Rad;
        float targetY = lancer.Player.transform.position.y + Mathf.Sin(angleRad) * radius;
        float targetX = lancer.Player.transform.position.x + Mathf.Cos(angleRad) * radius;
        newPos = new Vector2(targetX, targetY);
    }
    while (!IsNotInObstacle(newPos)); // 继续尝试直到找到有效位置
    
    targetPos = newPos;
    
    }

    void MoveBoss()
{
    float distance = Vector2.Distance(rb2.position, targetPos);
    if (distance < 0.1f)
    {
        SetNewTargetPosition(); // 到达目标后选择新的目标位置
    }
    else
    {
        TheBossMove(targetPos,1); // 按照目标位置移动 Boss
    }
}
#region 攻击1
    void MoveBossAttackOne(){
        float X;
    float currentDistance = Vector2.Distance(rb2.position, lancer.Player.transform.position);
    // Debug.Log("当前距离" + currentDistance);

    if (currentDistance > 4f)
    {
        X = lancer.Player.transform.position.x + (lancer.transform.localScale.x > 0 ? Random.Range(2f, 5f) : Random.Range(-5f, -2f));
    }
    else if (currentDistance < 2f)
    {
        X = lancer.Player.transform.position.x + (lancer.transform.localScale.x > 0 ? Random.Range(-5f, -2f) : Random.Range(2f, 5f));
    }
    else
    {
        X = rb2.position.x;
    }

        float Y=lancer.Player.transform.position.y;
        attackOneTarget=new Vector2(X,Y);
        if(IsNotInObstacle(attackOneTarget)){
        BossAttackOne();
        }
    }
    void BossAttackOne(){
       // float distance=Vector2.Distance(attackOneTarget,rb2.position);
        if(lancer.IsEnableAttackOne){
          //  Debug.Log("进入攻击1");
          lancer.IsEnableAttackOne=false;
            lancerState.changeState(lancerState.lancerAttackOne);
        }
        else{

            TheBossMove(attackOneTarget,1.2f);
        }
    }
#endregion

#region  攻击3
    void MoveBossAttackThree(){
       
        attackThreeTarget=lancer.Player.transform.position;
       
        BossAttackThree();
    }

    void BossAttackThree(){
        //float distance=Vector2.Distance(attackThreeTarget,rb2.position);
        if(lancer.IsEnableAttackThree){
            lancer.IsEnableAttackThree=false;
    //      Debug.Log("进入攻击3");
            lancerState.changeState(lancerState.lancerAttackThree);
        }
        else{

            TheBossMove(attackThreeTarget,1.2f);
        }
    }
#endregion


#region 攻击2
    void MoveBossAttackTwo(){
       
        attackTwoTarget=lancer.Player.transform.position;
        BossAttackTwo();
    }

   void BossAttackTwo(){
   //  float distance=Vector2.Distance(attackTwoTarget,rb2.position);
        if(lancer.IsEnableAttackTwo){
            lancer.IsEnableAttackTwo=false;
        //    Debug.Log("进入攻击2");
            lancerState.changeState(lancerState.lancerAttackTwo);
        }
        else{

            TheBossMove(attackTwoTarget,1.3f);
        }
   }

   

#endregion
    private IEnumerator AttackPlayerForDuration(float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate(); // 等待下一帧
        }

        // 时间到后切换状态
        lancer.ChooseAttackMode();
    }


    void TheBossMove(Vector2 Pos,float multiply){
         Vector2 direction = (Pos - rb2.position).normalized;
        Vector2 movement= direction*lancer.setlancerAttackSpeed()*multiply;
        rb2.velocity = movement;
      //  Debug.Log("当前速度" + movement);
    }

    
}
