
using UnityEngine;

public class ReturnGameScene : MonoBehaviour
{
   
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("PlayerTrigger")){
      Soldier soldier=other.GetComponentInParent<Soldier>();
        if(soldier!=null){
            soldier.setIsIdle();
            soldier.InStore=false;
        }

        SceneLoader.Instance.LoadGameScene();
       }

   }
}
