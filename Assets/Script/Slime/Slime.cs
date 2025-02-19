
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Slime : MonoBehaviour,Ihurt,IMonster
{

    [Header("自带音效")]
    public AudioData attack;

    [SerializeField] GameObject move;
    public void TakeDamage(float Damage)
    {
        setIsHurt();
        Health-=Damage;
        if (Health <= 0){
            boxCollider2D.enabled = false;
            if (move != null){
                move.SetActive(false);
            }
            IsDeath=true;
        }
    }
    public void setIsAttack()
    {
      //  Debug.Log("准备进攻");
        IsAttack=true;
    }
    public float ReturnDamage()
    {
       return damage ;
    }

    public bool setIsDeath()
    {
       return IsDeath;
    }

    [Header("判断条件")]

    public bool IsAttack;
    public bool IsHurt;
    public bool IsDeath;
    public bool IsMove;
    public bool IsIdle;

    [Header("基本属性")]


    public float damage;
    public float health;
    public float moveSpeed;
    
    public float currentMoveSpeed;
    
    BoxCollider2D boxCollider2D;
        Rigidbody2D rb2;
    private void Awake() {
       rb2=GetComponent<Rigidbody2D>();
       Health=Maxheath;
       updateSpeed();
       boxCollider2D=GetComponent<BoxCollider2D>();
    }
/// <summary>
/// 这个是从怪物上取得的钱;
/// </summary>
    public int countPoint;
  //  public float weight;
   [SerializeField] private float Maxheath;
    public float Health{
        get { return health; }
        set { health = math.clamp(value,0,Maxheath); }
    }

    private void Start() {
        
         
    }

    public void setIsHurt()
    {
        IsHurt=true;
    }

    public IEnumerator MoveHit(float distance, Vector3 targetPos)
    {
        while(distance>=0){
           Vector3 newPosition = Vector3.Lerp(transform.position,targetPos, currentMoveSpeed*Time.fixedDeltaTime);
           rb2.MovePosition(newPosition);
            yield return new WaitForFixedUpdate(); 
            if(IsAttack){
                yield break;
            }
          }//此时在walk里面
    }

    public void setIsMove()
    {
       IsMove=true;
    }

    public void setIsIdle()
    {
        IsIdle=true;
    }

    public void setCurrentMoveSpeed(){
        currentMoveSpeed=0;
    }
    public void updateSpeed(){
        currentMoveSpeed=moveSpeed;
    }
    public void StopMove(){
        rb2.velocity=new Vector3(0,0,0);
    }

    private void OnDisable() {
        if(!move.activeSelf){
            move.SetActive(true);
        }
    }
}
