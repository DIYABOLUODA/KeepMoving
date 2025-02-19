
using UnityEngine;

public class SlimeState : MonoBehaviour
{
    public IState slimeDeath;
    public IState slimeHurt;
  public IState slimeIdle ;
  public IState slimeAttack;
    public IState slimeWalk;
  
   Animator animator;

   Slime slime;
   IState currentState;
   private void Start() {
    slime=GetComponent<Slime>();
    animator=GetComponent<Animator>();


    slimeAttack=new SlimeAttack(this,animator,slime);
    slimeIdle=new SlimeIdle(this,animator,slime);
    slimeDeath=new SlimeDeath(this,animator,slime);
    slimeHurt=new SlimeHurt(this,animator,slime);
    slimeWalk=new SlimeWalk(this,animator,slime);
    setState(slimeIdle);
   }
public void setState(IState state) {

    currentState=state;
}
private void Update() {
if(currentState!=null){
    currentState.LogicUpdate();
}
}
private void FixedUpdate() {
    if(currentState!=null){
    currentState.PhysicUpdate();
    }
}

public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.Enter();
        }
    }
}
