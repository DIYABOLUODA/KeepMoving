
using UnityEngine;

public class ScoreManager :SingletonManager<ScoreManager>
{
    int count;//钱数据
    float pathScore;//公里数据

   [SerializeField]  float targetPathScore;
#region count
    public void ResetCount(){
        count = 0;
    //    Money.UpdateCount(count);
    }
    public void AddCount(int countPoint){
       count+=countPoint;
  //     Money.UpdateCount(count);
    }

    public int GetCount(){
        return count;
        //Debug.Log("" + count);
    }
#endregion


   public void ResetPathScore(){
        pathScore = 0;
        PathScore.UpdateScore(pathScore);


    }

    public void AddPathScore(float scorePoint){
        pathScore += scorePoint;
        PathScore.UpdateScore(pathScore);
        if(pathScore>=targetPathScore&&SceneLoader.Instance!=null){

        EventManager.Instance.IsInBossScene();//还没写事件内容呢
       SceneLoader.Instance.LoadBossScene();
    }
    }

    public float GetPathScore(){
        return pathScore;
       
    }
}

