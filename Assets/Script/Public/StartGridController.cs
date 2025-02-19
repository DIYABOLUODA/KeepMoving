using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartGridController : MonoBehaviour
{
  public GameObject loadGameSceneTrigger;
  public GameObject loadStoreSceneTrigger;

  public GameObject player;
    
  public GameObject EndMap;
  
   void OnEnable()
   {
       if(EventManager.Instance!=null){
        EventManager.Instance.LoadStoreScene+=LoadedStore;
        EventManager.Instance.StoreToGameScene+=storeToGameScene;
        EventManager.Instance.AchievedTargetScore+=LoadBossScene;
       }
   }

    private void LoadedStore()
    {
      if(!loadStoreSceneTrigger.activeSelf)
        loadStoreSceneTrigger.SetActive(!loadStoreSceneTrigger.activeSelf);
      if(loadGameSceneTrigger.activeSelf){
        loadGameSceneTrigger.SetActive(!loadGameSceneTrigger.activeSelf);
      }
     transform.position=new Vector3(4,0,0)+player.transform.position;
      //改一下，等到选择结束后再改成这个
  //   PlayerStateMachine playerStateMachine=player.GetComponent<PlayerStateMachine>();
  //   if(playerStateMachine!=null){
  //          playerStateMachine.SwitchState(typeof(SoldierMove));
  //   }

  Soldier soldier=player.GetComponent<Soldier>();
   if(soldier!=null){
    soldier.setIsMove();
   }
    }
    private void storeToGameScene(){
      if(loadStoreSceneTrigger.activeSelf){
          loadStoreSceneTrigger.SetActive(!loadStoreSceneTrigger.activeSelf);
      }
      if(!loadGameSceneTrigger.activeSelf){
        loadGameSceneTrigger.SetActive(!loadGameSceneTrigger.activeSelf);
    }
    transform.position=new Vector3(4,0,0)+player.transform.position;
      //改一下，等到选择结束后再改成这个
  //  PlayerStateMachine playerStateMachine=player.GetComponent<PlayerStateMachine>();
  //   if(playerStateMachine!=null){
   //         playerStateMachine.SwitchState(typeof(SoldierMove));
   //  }
   Soldier soldier=player.GetComponent<Soldier>();
   if(soldier!=null){
    soldier.setIsMove();
   }
}

private void LoadBossScene(){
  EndMap.gameObject.SetActive(true);
  gameObject.SetActive(false);
  EndMap.transform.position=player.transform.position;
}

private void OnDisable() {
  if(EventManager.Instance!=null){
        EventManager.Instance.LoadStoreScene-=LoadedStore;
        EventManager.Instance.StoreToGameScene-=storeToGameScene;
         EventManager.Instance.AchievedTargetScore-=LoadBossScene;
       }
}
}