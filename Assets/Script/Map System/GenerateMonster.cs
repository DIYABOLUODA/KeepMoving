using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateMonster : MonoBehaviour
{
    public Tilemap tilemap;
    public MonsterWeight[] monsters;
    public ItemWeight[] items;
    private List<Vector3> enableUsePos;
    private List<Vector3> ItemenableUsePos;
    public int monstergenerateCount;
    public int itemGenerateCount;
    private Queue<GameObject> disMonster;
    private Queue<GameObject> disItem;
    void OnEnable()
    {
        if(EventManager.Instance!=null){
        EventManager.Instance.GenerateMonster += monster;
        }
        disMonster = new Queue<GameObject>();
        disItem = new Queue<GameObject>();
        enableUsePos=new List<Vector3>();
        ItemenableUsePos=new List<Vector3>();
    }
    
    private void monster()
    {
       
       if (EventManager.Instance != null && EventManager.Instance.GenerateMonsterHasSubscribers())
        {
            EventManager.Instance.GenerateMonster -= monster;
        }
        enableUsePos=new List<Vector3>();
       
       // tilemap.CompressBounds();
        BoundsInt boundsInt = tilemap.cellBounds;
        
        for (int x = boundsInt.xMin; x < boundsInt.xMax; x++)
        {
            for (int y = boundsInt.yMin; y < boundsInt.yMax; y++)
            {
                Vector3Int Pos = new Vector3Int(x, y, 0);
                if (tilemap.HasTile(Pos))
                {
                    Vector3 worldPos = tilemap.GetCellCenterWorld(Pos);
                    enableUsePos.Add(worldPos);
                }
            }
        }
        if(enableUsePos!=null){
      ItemenableUsePos =new List<Vector3>(MonsterEnableUsePos(enableUsePos));//这里不知道对不对
       ItemGenerateEnableUsePos(ItemenableUsePos);
        }

       // Debug.Log("一共" + enableUsePos.Count + "格子");


      //  for (int i = 0;i<generateCount;i++){

       //      int randomValue = Random.Range(0, enableUsePos.Count);
      
        //        GameObject themonster=ChooseMonster(monsters);
        //        Debug.Log("生成："+themonster.name);
        //       GameObject monster= PoolManager.Release(themonster, enableUsePos[randomValue]+ new Vector3(4,0,0));
        //        disMonster.Enqueue(monster);//添加已经生成的怪物
       // 
    //}
}
    private List<Vector3> MonsterEnableUsePos(List<Vector3> enableUsePos){
           //  Debug.Log("一共" + enableUsePos.Count + "格子");

        for (int i = 0;i<monstergenerateCount;i++){

             int randomValue = Random.Range(0, enableUsePos.Count);
              //  Debug.Log("---------------------------------------------" + enableUsePos.Count + "格子");
                GameObject themonster=ChooseMonster(monsters);
             //   Debug.Log("生成："+themonster.name);
               GameObject monster= PoolManager.Release(themonster, enableUsePos[randomValue]/*+ new Vector3(4,0,0)*/);
                disMonster.Enqueue(monster);//添加已经生成的怪物    
                enableUsePos.RemoveAt(randomValue);
    }
    return enableUsePos;
}

    private void/*List<Vector3>*/ ItemGenerateEnableUsePos(List<Vector3> enableUsePos){
           for (int i = 0;i<itemGenerateCount;i++){

             int randomValue = Random.Range(0, enableUsePos.Count);
             //   Debug.Log("---------------------------------------------" + enableUsePos.Count + "格子");
                GameObject theItem=chooseItem(items);
             //  Debug.Log("生成："+theItem.name);
               GameObject item= PoolManager.Release(theItem, enableUsePos[randomValue]+ new Vector3(4,0,0));
               disItem.Enqueue(item);
                enableUsePos.RemoveAt(randomValue);
                
    }
   // return enableUsePos;
    }

    public GameObject chooseItem(ItemWeight[] items){
        float totalWeight = 0;
        GameObject chooseItem=null;
        foreach(ItemWeight item in items){
            totalWeight+=item.itemweight;
        }
       //  Debug.Log("总权重"+totalWeight);
         float weightSum=0;
         float randomValue=Random.Range(0,totalWeight);
         foreach(ItemWeight item in items){
            weightSum+=item.itemweight;
            if(weightSum>=randomValue){
                chooseItem=item.gameObject;
                break;
            }
         }
         return chooseItem;
    }
    public GameObject ChooseMonster(MonsterWeight[] monsters){
            float totalWeight = 0f;
            GameObject chooseMonster=null;
            foreach(MonsterWeight monster in monsters){
                totalWeight+=monster.weight;
            }
           // Debug.Log("总权重"+totalWeight);
            float randomValue = Random.Range(0, totalWeight);
         //   Debug.Log("随机数是："+randomValue);
            float weightSum=0f;
            foreach(MonsterWeight monster in monsters){
                weightSum+=monster.weight;

                if(weightSum>=randomValue){
                    chooseMonster=monster.gameObject;
                    break;
                }
            }
            return chooseMonster;
    }
    
    private void OnDisable()
    {
        if (EventManager.Instance != null)
        {
            
            while (disMonster.Count > 0)
            {
                GameObject game = disMonster.Dequeue();
                if(game!=null&&game.activeSelf){
                game.SetActive(false);
                }
                continue;
            }
            while (disItem.Count > 0){
                GameObject game = disItem.Dequeue();
                if (game!=null&&game.activeSelf){
                    game.SetActive(false);
                }
                continue;
            }
         //   Debug.Log("已经清除完成");
            if (EventManager.Instance.GenerateMonsterHasSubscribers())
            {
                EventManager.Instance.GenerateMonster -= monster;
            }
        }
        enableUsePos.Clear();
        ItemenableUsePos.Clear();
    }
}
