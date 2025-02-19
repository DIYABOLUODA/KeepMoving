
using UnityEngine;

public class SkeletonState : MonoBehaviour
{
    #region 状态
    public IState skeletonIdle;
    public IState skeletonAttackOne;
    public IState skeletonHurt;
    public IState skeletonAttackTwo;
    public IState skeletonDeath;
    public IState skeletonWalk;
    #endregion


    private Skeleton skeleton;
    private Animator animator;

    IState currentState;
    private void Start() {
        animator = GetComponent<Animator>();
        skeleton=GetComponent<Skeleton>();

        skeletonIdle=new SkeletonIdle(this,animator,skeleton);
        skeletonAttackOne =new SkeletonAttackOne(this,animator,skeleton);
        skeletonHurt=new SkeletonHurt(this,animator,skeleton);
        skeletonAttackTwo=new SkeletonAttackTwo(this,animator,skeleton);
        skeletonDeath=new SkeletonDeath(this,animator,skeleton);
        skeletonWalk=new SkeletonWalk(this,animator,skeleton);
        changeState(skeletonIdle);
    }

    
    void Update() {
        if (currentState != null)
        currentState.LogicUpdate();
    }

    private void FixedUpdate() {
        if(currentState!=null)
        currentState.PhysicUpdate();
    }

    public void changeState(IState newState) {
        if(currentState!=null){
        currentState.Exit();
        }

        currentState=newState;
        if(currentState!=null){
        currentState.Enter();
        }
    }
}
