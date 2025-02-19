using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadStoreNow : MonoBehaviour
{
  public GameObject StoreMap;
  Vector3 storeMapPos;
    
void OnEnable()
{
    if(EventManager.Instance!=null){
      storeMapPos=EventManager.Instance.IsStoreMapLoad();
      EventManager.Instance.StoreMap+=GenerateStoreMap;
  }
}
  
private void GenerateStoreMap(){
  Instantiate(StoreMap,storeMapPos,Quaternion.identity,transform);
}
  

  private void OnDisable() {
    if(EventManager.Instance!=null){
      EventManager.Instance.StoreMap-=GenerateStoreMap;
    }
  }
}
