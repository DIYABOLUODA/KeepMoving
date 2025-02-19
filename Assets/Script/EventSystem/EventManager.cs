using System;

using UnityEngine;

public class EventManager : SingletonManager<EventManager>
{
    public event Action alphaDown;//alpha值下降事件
    public void alphaDownTriggered(){
        alphaDown?.Invoke();
    }
   public bool alphaDownHasSubscribers(){
       return alphaDown!=null&&alphaDown.GetInvocationList().Length>0;
    }
    public event Action alphaUp;//alpha值上升事件
    public void alphaUpTriggered(){
        alphaUp?.Invoke();
    }
    public bool alphaUpHasSubscribers(){
       return alphaUp!=null&&alphaUp.GetInvocationList().Length>0;
    }


    public event Action GenerateMonster;
    public void GeneratedMonster(){
        
        GenerateMonster?.Invoke();
    }
    public bool GenerateMonsterHasSubscribers(){
        return GenerateMonster!=null&&GenerateMonster.GetInvocationList().Length>0;
    }

    public event Action DisGenerateMonster;
    public void DisGeneratedMonster(){
        DisGenerateMonster?.Invoke();
    }
    public bool DisGenerateMonsterHasSubscribers(){
        return DisGenerateMonster!=null&&DisGenerateMonster.GetInvocationList().Length>0;
    }
#region 目前可能没啥用

    public event Func<GameObject,float> LoadMap;
    public void LoadMapHasSubscribers(GameObject Pos){
        LoadMap?.Invoke(Pos);  
    }

    public event Func<Vector3> LoadStartMap;
    public Vector3 LoadStartMapHasSubscribers(){
        Vector3 Pos=new Vector3(0,0,0);
        if(LoadStartMap!=null){
      Pos= LoadStartMap.Invoke();
        }
       return Pos;
    }
    
#endregion

#region 
    public event Action LoadNextMap;
    public void IsLoadNextMap(){
       LoadNextMap?.Invoke();
    }
    public event Func<GameObject,GameObject> GetPreviousMap;
    public void IsGetPreviousMap(GameObject currentMap){

        GetPreviousMap?.Invoke(currentMap);
    }

    public event Func<GameObject> SentCurrentMap;
    public GameObject ISSentCurrentMap(){
       return SentCurrentMap?.Invoke();
    }
#endregion


#region 关于商店地图的加载
   public event Action LoadStoreScene;
   public void IsLoadStoreScene(){
    LoadStoreScene?.Invoke();
   }

    public event Func<Vector3> StoreMapLoad;
    public Vector3 IsStoreMapLoad(){
        Vector3 Pos=new Vector3(0,0,0);
   if(StoreMapLoad!=null){
   Pos= StoreMapLoad.Invoke();
   } 
   return Pos;
    } 

    public event Action StoreMap;
    public void IsStoreMap(){
        StoreMap?.Invoke();
    }

#endregion


#region 从商店返回游戏场景


    public event Action StoreToGameScene;
    public void IsStoreToGameScene(){
        StoreToGameScene?.Invoke();
    }
#endregion


#region Boss事件

   public event Action BossIdle;
   public void IsBossIdle(){
    BossIdle?.Invoke();
   }
#endregion


#region  300m事件

public event Action InBossScene;
public void IsInBossScene(){
    InBossScene?.Invoke();
}


public event Action AchievedTargetScore;
public void IsAchievedTargetScore(){
    AchievedTargetScore?.Invoke();
}

#endregion
}
