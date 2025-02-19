
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
  //PolygonCollider2D polygonCollider2D;
   Vector3 targetPos;
    IMonster monster;
    Coroutine moveCoroutine;
   float distance=>Vector3.Distance(targetPos,transform.position);

    private void OnEnable() {
     //   polygonCollider2D=GetComponent<PolygonCollider2D>();
    }
   void Start()
   {
       
   }
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("PlayerTrigger")){
           monster=GetComponentInParent<IMonster>();
           if(monster!=null){
            targetPos=other.transform.position;
            monster.setIsMove();
            if(moveCoroutine==null&&gameObject.activeSelf){
       moveCoroutine= StartCoroutine(monster.MoveHit(distance,targetPos));
            }
           }
       }
   }
   private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("PlayerTrigger")){
            if(monster!=null)
            monster.setIsIdle();
            if(moveCoroutine!=null){
            StopCoroutine(moveCoroutine);
            moveCoroutine=null;
            }
        }
   }

  
}


