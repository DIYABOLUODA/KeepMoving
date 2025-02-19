
using UnityEngine;

public class EnableAttack : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
              Debug.Log("谁碰撞到了："+collision.name);
           IBuff buff= collision.GetComponent<IBuff>();
           if(buff!=null){
         //   Debug.Log("hahha，能够攻击啦");
           buff.BuffEnableAttack();
           }
           else{
            Debug.Log("未找到接口");
           }
            transform.gameObject.SetActive(false);
        }
    }
}
