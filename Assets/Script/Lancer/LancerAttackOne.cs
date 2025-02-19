using System.Collections;
using UnityEngine;

public class LancerAttackOne : IState
{
    LancerState lancerState;
    Animator animator;
    Lancer lancer;
    Rigidbody2D rb2;
    private int power = 3;
    BoxCollider2D box;
    float startStateTime;
    float stateDuration => Time.time - startStateTime;
    bool IsAnimationFinished => stateDuration >= 1.5f;

   Coroutine moveCoroutine;


    Vector2 finalDirection;
    public LancerAttackOne(LancerState lancerState, Animator animator, Lancer lancer)
    {
        this.lancerState = lancerState;
        this.animator = animator;
        this.lancer = lancer;
    }

    public void Enter()
    {
         lancer.gameObject.layer=LayerMask.NameToLayer("BossAttack");
        rb2 = lancer.GetComponent<Rigidbody2D>();
        rb2.isKinematic=true;
        box=lancer.GetComponent<BoxCollider2D>();
        box.enabled=false;
    if (moveCoroutine != null)
        {
            lancer.StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
        moveCoroutine = lancer.StartCoroutine(FollowPlayer(0.25f)); 

        animator.Play("LancerAttackOne");
        startStateTime=Time.time;
    }

    public void Exit()
    {
        rb2.isKinematic = false;
         if (moveCoroutine != null)
        {
            lancer.StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        }
        lancer.gameObject.layer=LayerMask.NameToLayer("Boss");
        lancer.LancerPower-=power;
        box.enabled = true;
        //  Debug.Log("当前体力值"+lancer.LancerPower);
        lancer.SetRange();
    }

    public void LogicUpdate()
    {
       if(IsAnimationFinished){
        lancer.IsEnableAttackOne = false;
        lancer.IsAttackOne = false;
        lancerState.changeState(lancerState.lancerAttackIdle);
       }
    }

    public void PhysicUpdate()
    {
        MoveBoss();
    }

   
   void AttackOne()
    {
        Vector2 direction = ((Vector2)lancer.Player.transform.position - rb2.position).normalized;
        finalDirection = direction;

    }
    void MoveBoss()
    {
        


        if (stateDuration <= 0.25f)
        {
            Vector2 direction = ((Vector2)lancer.Player.transform.position - rb2.position).normalized;
            rb2.velocity = direction * lancer.setlancerAttackSpeed() * 1.2f;
        }
        else
        {
            rb2.velocity = finalDirection * lancer.setlancerAttackSpeed() * 1.3f;
        }

      //  Debug.Log("当前的速度"+rb2.velocity);
        
       
    }

    IEnumerator FollowPlayer(float duration){
         float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.fixedDeltaTime;
            AttackOne();
            AudioManager.Instance.PlayRandomSFX(lancer.attackOneSFX);
            yield return new WaitForFixedUpdate(); 
        }
         finalDirection = ((Vector2)lancer.Player.transform.position - rb2.position).normalized;
    }
}
