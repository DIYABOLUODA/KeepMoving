using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateMap : MonoBehaviour
{
        
    
    Vector3 startMapPos;
    Tilemap tilemap;
    Vector3 lastGeneratePosition;

     public List<MapWeight> mapWeightGameObject; 
    private void Awake() {
    }
    private void OnEnable() {
        if(EventManager.Instance!=null)
        EventManager.Instance.LoadNextMap+=Generate;
    }
    private void Start() {//两套方案，有没有缓冲的
        startMapPos=EventManager.Instance.LoadStartMapHasSubscribers();
        if (startMapPos!=null){
           lastGeneratePosition=startMapPos;
           }
                Generate();
        }
    

   


       void Generate(){
       // Debug.Log("我开始生成地图了哦");
            GameObject generatedMap=MapPoolManager.MapRelease(chooseMap(),lastGeneratePosition);

           UpLoadPreviousMap getPreviousMap=generatedMap.GetComponent<UpLoadPreviousMap>();
            if(getPreviousMap!=null){
               
                getPreviousMap.previousMap=EventManager.Instance.ISSentCurrentMap();
            }
             EventManager.Instance.GeneratedMonster();
            UpdateXoffset(generatedMap);
           
       }
    GameObject chooseMap(){
        GameObject chooseThis=null;
        float totalWeight = 0;
        foreach(var map in mapWeightGameObject){
            totalWeight+=map.weight;
        }
        float randomValue = Random.Range(0, totalWeight);
        float weightSum=0;
        foreach(var map in mapWeightGameObject){
            weightSum+=map.weight;
            if (weightSum>randomValue){
                chooseThis=map.gameObject;
                break;
            }
        }
        return chooseThis;
       }
        void UpdateXoffset(GameObject choosethis){//更新生成位置
        MapWeight mapWeight;
         mapWeight=choosethis.GetComponent<MapWeight>();
        lastGeneratePosition.x+=mapWeight.ReturnLength();
    }

private void OnDisable() {
    if(EventManager.Instance!=null)
        EventManager.Instance.LoadNextMap-=Generate;
}
}
