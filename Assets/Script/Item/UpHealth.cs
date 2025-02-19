
using UnityEngine;

public class UpHealth : MonoBehaviour
{   
    public float healthValue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.CompareTag("PlayerTrigger")||collision.CompareTag("Monster")){

        IBuff buff = collision.GetComponentInParent<IBuff>();
        
          //  ScoreManager.Instance.AddCount(-Value);
          if(buff != null){

            buff.BuffMaxHealthUp(healthValue);
            gameObject.SetActive(false);
          }
       
         }
    }
}
