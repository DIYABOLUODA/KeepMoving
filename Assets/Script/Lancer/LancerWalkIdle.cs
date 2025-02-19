using System.Collections;
using UnityEngine;

public class LancerWalkIdle : IState
{
    LancerState lancerState;
    Animator animator;
    Lancer lancer;
    public float radius=5f;
    public float arcAngle = 65f;
    Rigidbody2D rb2; // 使用 Rigidbody2D



    Vector2 targetPos;
    private Coroutine moveCoroutine;

    public LancerWalkIdle(LancerState lancerState, Animator animator, Lancer lancer)
    {
        this.lancerState = lancerState;
        this.animator = animator;
        this.lancer = lancer;
    }

    public void Enter()
    {
        
       rb2=lancer.GetComponent<Rigidbody2D>();
       SetNewTargetPosition();
       animator.Play("LancerWalkIdle");
        if (moveCoroutine != null)
        {
            lancer.StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
        moveCoroutine = lancer.StartCoroutine(WalkAroundPlayerForDuration(4.2f)); // 6秒钟围绕玩家移动
    }

    public void Exit()
    {
        if (moveCoroutine != null)
        {
            lancer.StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
    }

    public void LogicUpdate()
    {
    
        if (lancer.IsHurt||lancer.IsDeath)
        {
            lancer.IsMove = false;
            lancerState.changeState(lancerState.lancerHurt);
        }else if(lancer.IsAttack){
            lancer.IsMove = false;
            lancerState.changeState(lancerState.lancerAttackIdle);
        }
    }

    public void PhysicUpdate()
    {
        lancer.transform.localScale = lancer.Player.transform.position.x > lancer.transform.position.x ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
        MoveBoss();
    }


    private bool IsNotInObstacle(Vector3 pos)
    {
        return Physics2D.OverlapCircle(pos, 0.1f) == null;
    }

    private IEnumerator WalkAroundPlayerForDuration(float duration)
    {
       
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate(); // 等待下一帧
        }

        // 时间到后切换状态
        lancer.LancerPower+=10;
       lancer.IsAttack=true;
      // Debug.Log("进入攻击模式");
    }





    void SetNewTargetPosition(){
    
        Vector2 newPos;
        do{
        float angle = Random.Range(-arcAngle / 2, arcAngle / 2);
        float angleRad = angle * Mathf.Deg2Rad;
        float targetY = lancer.Player.transform.position.y + Mathf.Sin(angleRad) * radius;
        float targetX = lancer.Player.transform.position.x + Mathf.Cos(angleRad) * radius;
        newPos = new Vector2(targetX, targetY);

        }  while(!IsNotInObstacle(newPos));
        
        targetPos=newPos;


    }

    void MoveBoss(){
        float distance=Vector2.Distance(rb2.transform.position,targetPos);
        if(distance<0.1f){
            SetNewTargetPosition();
        }
       else{
        TheBossMove(targetPos,1);
       }
    }

     void TheBossMove(Vector2 Pos,float multiply){
         Vector2 direction = (Pos - rb2.position).normalized;
        Vector2 movement= direction*lancer.setlancerSpeed()*multiply;
        rb2.velocity = movement;
      //  Debug.Log("当前速度" + movement);
    }
}
