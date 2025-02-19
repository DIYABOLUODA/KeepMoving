
using System;
using System.Collections;
using UnityEngine;

public class Soldier : MonoBehaviour,Ihurt,IBuff
{

    public AudioData attackOne;
    public AudioData attackTwo;
    public AudioData bow;
    public AudioData hurt;
    public AudioData RecoverSFX;

    [Header("判断条件")]
    public GameObject recover;

    public bool IsIdle;
    public bool IsMove;
    
    public bool InStore;
    public bool InBoss;
    public bool IsAttack;//Q攻击
    public bool IsAttackTwo;//E攻击
    public bool IsShoot;//空格攻击

    public bool IsHurt;
    public bool IsDeath;
    public bool needRecovers=>currenthealth<Maxhealth;
    [Header("属性")]
    public float reSpeed;
    public bool needRePower=>Power<MaxPower;
    public float powerFillAmount=>Power/MaxPower;
   [SerializeField] StateBar HUD_Bar;
   [SerializeField] Ability ability;
   [SerializeField] GameObject Shock;

   PlayerInput input;
    [SerializeField] protected float Maxhealth;
    public float maxhealth{
        get=>Maxhealth;
        set=>Maxhealth =value;
    }
    [SerializeField] protected float Currenthealth;
    public float currenthealth
    {
        get => Currenthealth;
        set => Currenthealth = Mathf.Clamp(value, 0, Maxhealth);
    }

    [Header("能量")]
    [SerializeField] protected float maxPower;
     public float MaxPower{
        get => maxPower;
        set => maxPower = value;
     }
    [SerializeField] protected float power;

    public float Power{
        get => power;
        set => power =Mathf.Clamp(value,0,MaxPower);
    }
    [Header("水平速度")]
    public float MaxXSpeed;
    public float MinXSpeed;
    public float CurrentXSpeed;
    public float currentXSpeed{
        get => CurrentXSpeed;
        set => CurrentXSpeed = Mathf.Clamp(value,MinXSpeed,MaxXSpeed);
    }

    [Header("水平速度")]
    public float YSpeed;


    [Header("伤害")]
    [SerializeField] private float Damage;

  //  [Header("减速倍率")]
   // public int SlowDownPower;
  //  [Range(0, 1)] public float slowDownFactor;
   // public float slowDownDuration = 1f;//�����������һ�����ܣ����

 //  Coroutine rePowerCoroutine;
    private void Awake()
    {
        currenthealth = Maxhealth;
        currentXSpeed = MaxXSpeed;
      
        
        input=GetComponent<PlayerInput>();    
    }

    private void OnEnable() {
        EventManager.Instance.InBossScene+=setInBoss;
        EventManager.Instance.BossIdle+=BossIdleRecover;
    }
    
    void Start()
    {
        HUD_Bar.Initialize(Currenthealth,Maxhealth);
         startPowerCorout();
      //  HUD_Bar.InitializePower(Power,MaxPower,needRePower);
      //  retrunAttPowerCount();
    // startPowerCorout();
    }

    #region IBuff
    /// <summary>
    /// 拾取后增强玩家最大生命值，但是表现形式有点那个，可能会被误解，要不就是在这个里面调用回复生命的函数；
    /// </summary>
    /// <param name="UpMaxHealthValue">传入恢复生命的值</param>
    
    public void BuffMaxHealthUp(float UpMaxHealthValue)
    {
        Maxhealth += UpMaxHealthValue;
          if(AudioManager.Instance!=null){
            AudioManager.Instance.PlayRandomSFX(RecoverSFX);
        }
        //最大生命增加，感觉有问题
        HUD_Bar.UpdateState(Currenthealth,Maxhealth);
        //破天荒居然是对的;
    }
    public void BuffMaxSpeedUp(float UpXSpeedValue)
    {
        MaxXSpeed += UpXSpeedValue;
       //  Debug.Log("速度怎加:" + UpXSpeedValue);
    }
    /// <summary>
    /// 角色拾取道具后，伤害加高
    /// </summary>
    /// <param name="UpDamegeValue">传入物品能加高的攻击值</param>
    public void BuffDamageUp(float UpDamegeValue)
    {
        Damage += UpDamegeValue;
        if(AudioManager.Instance!=null){
            AudioManager.Instance.PlayRandomSFX(RecoverSFX);
        }
       // Debug.Log("���������ӣ�����������:" + UpDamegeValue);
    }
    //治疗角色；
    public void BuffHealthUp(float UpHealthValue){
        BossIdleRecover();
        currenthealth+=UpHealthValue;
          if(AudioManager.Instance!=null){
            AudioManager.Instance.PlayRandomSFX(RecoverSFX);
        }
        HUD_Bar.UpdateState(currenthealth,maxhealth);
    }
    /// <summary>
    /// 角色获取道具后，可以攻击
    /// </summary>
     public void BuffEnableAttack()
    {
 //      EnableAttack=true;
     //  Debug.Log(gameObject.name+"能够攻击，EnableAttack为："+EnableAttack.ToString());
    }
    public bool BuffISNeedRecovers()
    {
        return needRecovers;
    }

#endregion


    /// <summary>
    /// 角色受到伤害
    /// </summary>
    /// <param name="Damage">传入攻击者的伤害</param>
    public void TakeDamage(float Damage)
    {
        IsHurt = true;
        currenthealth -= Damage;
        HUD_Bar.UpdateState(Currenthealth,Maxhealth);
        if (currenthealth <= 0)
        {
            IsDeath = true;
        }

    }
   public void setIsAttack()
    {
//        IsAttack = true;
   }

    public bool setInStore(bool active){
        InStore=active;
        return InStore;
    }
   
   public void setPlayerScale(){
        transform.localScale=new Vector3(-transform.localScale.x,1,1);
   }


    public void setIsIdle(){
        IsIdle = true;
    }

    public void setIsMove(){
        IsMove = true;
    }
    public float ReturnDamage()
    {
        return Damage;
    }
    public bool setIsDeath()
    {
         HUD_Bar.UpdateState(0,Maxhealth);
        return IsDeath;
    }

    public void setInBoss(){
        InBoss = true;
    }

    public void setIsHurt()
    {
        IsHurt=true;
    }

#region  角色自身能力



IEnumerator waitCoroutine(){
    float time =0;
    while(time < 1.4f){
        time+=0.2f;
        yield return new WaitForSeconds(0.2f);
    }
}
public void startPowerCorout(){
    StartCoroutine(RePowerAbility());
}
public void startInitalizePower(){
    HUD_Bar.InitializePower(Power,MaxPower);
   // ability.SetObjActive();
}
IEnumerator  RePowerAbility(){
  //  Debug.Log("开始回复体力");
    while(needRePower){
           float currentPower=Mathf.MoveTowards(Power,MaxPower,reSpeed*Time.deltaTime);
           //这里就传给这个HUD
           Power=currentPower;
         //  Debug.Log("回了"+Power)
           HUD_Bar.InitializePower(Power,MaxPower);
            ability.SetObjActive();
           yield return Time.fixedDeltaTime;
            if(IsAttack||IsAttackTwo||IsShoot){
                StartCoroutine(waitCoroutine());
                yield break;
            }
           }
    }


public float returnAttPowerCount(){
   NeedPower needPower;
   needPower=ability.attackOne.GetComponent<NeedPower>();
   return  needPower.needPowerCount;
}

public float returnAttTwoPowerCount(){
    NeedPower needPower;
    needPower=ability.attackTwo.GetComponent<NeedPower>();
    return needPower.needPowerCount;
}

public float returnShootPowerCount(){
     NeedPower needPower;
    needPower=ability.shoot.GetComponent<NeedPower>();
    return needPower.needPowerCount;
}
#endregion






void BossIdleRecover(){
    currenthealth+=15;
    HUD_Bar.UpdateState(currenthealth,maxhealth);
    recover.SetActive(true);
}





 private void OnDisable() {
        if(SceneLoader.Instance!=null&&currenthealth==0){
            SceneLoader.Instance.LoadOverScene();
        }
     //   EventManager.Instance.AchievedTargetScore-=setIsIdle;
      EventManager.Instance.InBossScene-=setInBoss;
       EventManager.Instance.BossIdle-=BossIdleRecover;
    }
}

