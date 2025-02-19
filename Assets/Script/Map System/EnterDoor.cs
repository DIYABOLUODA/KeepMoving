using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerTrigger")){
             Soldier soldier=collision.GetComponentInParent<Soldier>();
             if(soldier!=null){
                soldier.setIsIdle();
                soldier.InStore=true;
            if(EventManager.Instance!=null){
               SceneLoader.Instance.LoadStoreScene();
            }
          }
        }
//设置他的速度为0;
            //触发进入商店事件
        }
    }

