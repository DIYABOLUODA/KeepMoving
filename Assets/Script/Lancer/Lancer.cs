using System.Collections;
using UnityEngine;
using Cinemachine;
using System.Threading;
using UnityEditor;
public enum AttackMode
{
    attackOne,
    attackTwo,
    attackThree,
    WalkIdle

}

public class Lancer : Boss,Ihurt
{
    [Header("自带音效")]

    public AudioData attackOneSFX;
    public AudioData attackTwoSFX;
    public AudioData attackThreeSFX;

    public AudioData hurtSFX;
    public GameObject tired;
   public BossBar bossBar;

    [Header("判断条件")]
    [SerializeField] public bool IsAttack;
    [SerializeField] public bool IsAttackOne;
    public bool IsEnableAttackOne;
    [SerializeField] public bool IsAttackTwo;
    public bool IsEnableAttackTwo;
    [SerializeField] public bool IsAttackThree;
    public bool IsEnableAttackThree;

    [SerializeField] public bool IsHurt;
    [SerializeField] public bool IsMove;
    [SerializeField] public bool IsDeath;
    [SerializeField] public bool IsIdle;

    [Header("骑兵倍率")]
    [SerializeField] float lancerAttackSpeedRate;
    [SerializeField] float lancerIdleSpeedRate;
    [SerializeField] float lancerAttackOneRate;
    [SerializeField] float lancerAttackTwoRate;
    [SerializeField] float lancerAttackThreeRate;
    [SerializeField] float lancerHealthRate;
    [SerializeField] float lancerWalkIdleTime;

    [Header("骑兵属性")]
    [SerializeField]  int takeDamageCount;
    public int TakeDamageCount{
        get=> takeDamageCount;
        set=> takeDamageCount = Mathf.Clamp(value,3,9);

    }
     float duration=3f;
     public float Duration{
        get => duration;
        set => duration = Mathf.Clamp(value,2,3);
     }
    [SerializeField]  int lancerPower;
    public int LancerPower{
        get=>lancerPower;
        set=>lancerPower=Mathf.Clamp(value, 0,10);
    }

   // public BoxCollider2D lancerTrigger;
    private int takeDamageCurrentCount = 0;
    private float lancerMaxHealth;
    private float lancerCurrentHealth;

    
    public float Health
    {
        get => lancerCurrentHealth;
        set => lancerCurrentHealth = Mathf.Clamp(value, 0, lancerMaxHealth);
    }

    [Header("目标")]
    public CinemachineVirtualCamera currentCamera;
    public GameObject Player;

    public GameObject LancerTrigger;
    public float radius;

    public BossAttackRange bossAttackRange;

#region 协程
BossTakeDamage bossTakeDamage;

    #endregion
   

    private void Awake()
    {
        lancerMaxHealth = lancerHealthRate * health;
        lancerCurrentHealth=0;
        rb2 = GetComponent<Rigidbody2D>();
        bossTakeDamage=GetComponent<BossTakeDamage>();
        bossBar.gameObject.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(BossHealth());
     //  targetPos = transform.position + GetRandomDirection();
    }

    public void SettakeDamageCount()
    {
        if(!IsIdle){
        takeDamageCurrentCount += 1;
        }

        if (takeDamageCurrentCount == TakeDamageCount)
        {
            setIsHurt(true);
            takeDamageCurrentCount = 0;
        }else{
               bossTakeDamage.hitColorChange();
        }
    }


    public void setIsAttack(bool active)
    {
        IsAttack = active;
    }

    public void setIsDeath(bool active)
    {
        IsDeath = active;
    }

    public void setIsHurt(bool active)
    {
        IsHurt = active;
    }

    public void TakeDamage(float Damage)
    {
        StopCoroutine(BossHealth());
      
       if(!IsIdle)
        Health -= Damage;//不是Idle,正常伤害
        else{
            Health-=Damage*1.5f;//是Idle,1。5倍伤害
        }

        bossBar.UpdateState(Health,lancerMaxHealth);
        Debug.Log("当前生命"+Health);
        SettakeDamageCount();
        if (Health <= 0)
        {
            Debug.Log("啊,死了");
            IsDeath = true;
        }
    }




public float setlancerSpeed(){
   // Debug.Log(speed*lancerSpeedRate);
    return speed*lancerIdleSpeedRate;
}
public float setlancerAttackSpeed(){
    return  speed*lancerAttackSpeedRate;
}
    


    public Vector2 GetRandomDirection()
    {
        int direction = Random.Range(0, 4);
         switch (direction)
    {
        case 0: return Vector2.up;
        case 1: return Vector2.down;
        case 2: return Vector2.left;
        case 3: return Vector2.right;
        default: return Vector2.right;
    }

    }

    public float GetAttackModeDamge(AttackMode attackMode){
        switch(attackMode){
            case AttackMode.attackOne:
            return Damage*lancerAttackOneRate;    
            case AttackMode.attackTwo:
            return Damage*lancerAttackTwoRate;
            case AttackMode.attackThree:
            return Damage*lancerAttackThreeRate;
            default: return Damage;
        }
    }


#region 选择状态
     public void ChooseAttackMode()
    {
       
        float[] weights = { 2, 3, 2, 1};
         int[] requiredPower = { 3, 2, 3,0};
        float totalWeight = 0;

        for(int i=0;i<requiredPower.Length;i++){
            if(LancerPower>=requiredPower[i]){
                totalWeight += weights[i];
            }
        }
        if(totalWeight == 0){
           IsMove=true;
            return;
        }

        float randomValue = Random.value * totalWeight;
        float cumulativeWeight = 0;

        for (int i = 0; i < weights.Length; i++)
        {
           if(LancerPower>=requiredPower[i]){
            cumulativeWeight+= weights[i];
            if(randomValue<cumulativeWeight){
                EnterAttackMode((AttackMode)i);
                break;
            }
           }
        }
    }


    private void EnterAttackMode(AttackMode attackMode)
    {
        IsAttackOne = attackMode == AttackMode.attackOne;
        IsAttackTwo = attackMode == AttackMode.attackTwo;
        IsAttackThree = attackMode == AttackMode.attackThree;
        IsMove=attackMode==AttackMode.WalkIdle;

     //   Debug.Log("IsAttackOne" + IsAttackOne);
     //   Debug.Log("IsAttackTwo" + IsAttackTwo);
     //   Debug.Log("IsAttackThree" + IsAttackThree);
        bossAttackRange.setRangeActive();
    }

public void SetRange(){
   // Debug.Log("uhkhuhiuhiuhihiuhiuhi");
     bossAttackRange.setRangeActive();
}

//public void StartWaitSomeTimeCoroutine(){
//    StartCoroutine(waitSomeTime());
//}
  
    #endregion

    #region 攻击
public void triggerAttack(AttackMode attackMode){
    switch(attackMode){
        case AttackMode.attackOne:
        IsEnableAttackOne=true;
        break;
        case AttackMode.attackTwo:
        IsEnableAttackTwo=true;
        break;
        case AttackMode.attackThree:
        IsEnableAttackThree=true;
        break ;
        case AttackMode.WalkIdle:
        IsMove=true;
        break;
    }
}

    public void setIsAttack()
    {
       
    }

   

    public bool setIsDeath()
    {
        return IsDeath;
    }

    public void setIsHurt()
    {
        
    }

    public float ReturnDamage()
    {
       return Damage;
    }

    #endregion


    #region 当前速度

    //void 
    #endregion


IEnumerator  BossHealth(){
    while(Health<lancerMaxHealth){
           float currenthealth=Mathf.MoveTowards(Health,lancerMaxHealth,240*Time.deltaTime);
           Health=currenthealth;
      //     Debug.Log("目前生命"+Health);
          bossBar.InitializeBossHealth(Health,lancerMaxHealth);
           yield return Time.fixedDeltaTime;
    }
  //  Debug.Log("啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊");
    Health=lancerMaxHealth;
     bossBar.InitializeBossHealth(Health, lancerMaxHealth); 
}

    private void OnDisable() {
        if(Health==0){
        SceneLoader.Instance.LoadLastScene();
        }

        
    }
}
