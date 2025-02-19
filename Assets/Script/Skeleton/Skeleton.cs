
using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : MonoBehaviour,Ihurt,IMonster
{
    [Header("自带音效")]
    public AudioData attack;
    [SerializeField] GameObject move;
    [Header("基本属性")]

    BoxCollider2D boxCollider2D;
    public int countPoint;//好像是钱；
    [SerializeField] float damage;
    float health;
    [SerializeField] float maxHealth;

   // [SerializeField] float speed;
    float Health{
        get =>health;
        set { health = Mathf.Clamp(value, 0,maxHealth); }
        
    }
    //移动速度
    [SerializeField] float moveSpeed;
    Rigidbody2D rb2;
    private void Awake() {
        Health=maxHealth;
        rb2=GetComponent<Rigidbody2D>();
        boxCollider2D=GetComponent<BoxCollider2D>();
    }
   
    [Header("判断条件")]
    public bool IsAttack;
    public bool IsHurt;
    public bool IsDeath;
    public bool IsMove;
    public bool IsIdle;
    public void TakeDamage(float Damage)
    {   IsHurt=true;
       Health-=Damage;
       if(Health<=0){
        boxCollider2D.enabled = false;
        if(move!=null){
            move.SetActive(false);
        }
        IsDeath=true;
       }
    }

    public void setIsAttack()
    {
        IsAttack=true;
    }

    public float ReturnDamage()
    {
        return damage;
    }

    public bool setIsDeath()
    {
       return IsDeath;
    }

    public void setIsHurt()
    {
        IsHurt=true;
    }
    public void setIsMove(){
        IsMove=true;
    }
    public void setIsIdle(){
        IsIdle=true;
    }

    IEnumerator IMonster.MoveHit(float distance, Vector3 targetPos)
    {
        while(distance>=0){
           Vector3 newPosition = Vector3.Lerp(transform.position,targetPos, moveSpeed*Time.fixedDeltaTime);
           rb2.MovePosition(newPosition);   
            yield return null;
             if(IsHurt){
                Debug.Log("不是哥们，你是真的刹不住脚啊，我的可爱骷髅");
                yield break;
            }
          }//此时在walk里面
         
    }

    public void StopMove(){
        rb2.velocity = Vector3.zero;
    }

    private void OnDisable() {
        if(!move.activeSelf){
            move.SetActive(true);
        }
    }
}
