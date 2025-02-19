using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoolManager : MonoBehaviour
{
   [SerializeField] MapPool[] MapPools;

    static Dictionary<GameObject,MapPool> poolDictionary;
    
    private void Awake() {
        poolDictionary = new Dictionary<GameObject, MapPool>();
        Initialize(MapPools);//这个实例化将这个pool里面的东西实例化了
    }
    void Initialize(MapPool[] mapPools){
    foreach(var pool in mapPools){//foreach循环，每一个池子都要实例;
        #if UNITY_EDITOR
            if (poolDictionary.ContainsKey(pool.Prefab))
            {
                Debug.LogError("same prefab in multiple pools! Prefab:" + pool.Prefab.name);
                continue;
            }
#endif
        poolDictionary.Add(pool.Prefab, pool);
        //新建一个gameobject类型，并且名字为预制体的名字
        Transform poolParent=new GameObject("MapPool:-"+pool.Prefab.name).transform;
        poolParent.parent=transform;
        pool.Initialize(poolParent);
    } 
   }

     public static GameObject MapRelease(GameObject prefab)
    {
#if UNITY_EDITOR
        if (!poolDictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could Not find Prefab:" + prefab.name);
            return null;
        }
#endif 
        return poolDictionary[prefab].preparedObject();
    }

    #region 这里改了
    public static GameObject MapRelease(GameObject prefab,/*float xoffset*/Vector3 Pos)
    {
#if UNITY_EDITOR
        if (!poolDictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could Not find Prefab:" + prefab.name);
            return null;
        }
#endif 
        return poolDictionary[prefab].preparedObject(Pos);
    }
    #endregion
}
