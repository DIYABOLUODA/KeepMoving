using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenerateNextMap : MonoBehaviour
{
 
  public GameObject currentMap;
  void OnEnable()
  {
    if(EventManager.Instance!=null)
      EventManager.Instance.SentCurrentMap+=SentMe;
  }
   void OnDisable()
    {
        // 取消订阅事件
        if(EventManager.Instance!=null)
        EventManager.Instance.SentCurrentMap-=SentMe;
    }
  private void Start() {
    //开始，通过事件获得前面那个map的prgameobject
  }
  void OnTriggerEnter2D(Collider2D other)
  {
      if(other.CompareTag("PlayerTrigger")){
        EventManager.Instance.IsLoadNextMap();
      }
  }

 GameObject SentMe(){
      return currentMap;
  }
}
