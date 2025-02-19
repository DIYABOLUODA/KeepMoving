
using System;
using System.Collections;
using UnityEngine;

public class arrowBullet : MonoBehaviour
{
   [SerializeField] float arrowDamage;
    [SerializeField] float arrowFlyTime;
    Ihurt ihurt;
    [SerializeField] float arrowFlySpeed;
    public float returnArrowFlySpeed(){
        return arrowFlySpeed;
    }

    private void OnEnable() {
      StartCoroutine(ShootCoroutine());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Monster")){
         
            ihurt=other.GetComponent<Ihurt>();
            if(ihurt!=null){
                ihurt.TakeDamage(arrowDamage);
                gameObject.SetActive(false);
            }
        }
    }
    IEnumerator ShootCoroutine(){
      float time=arrowFlyTime;
      while(time>=0){
         time-=1f;
         yield return new WaitForSeconds(1f);
      }
        if(gameObject.activeSelf&&gameObject!=null){}
            gameObject.SetActive(false);
        }
   }
    
    

