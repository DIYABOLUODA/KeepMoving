
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] Pool[] BuffItemPools;
    [SerializeField] Pool[] MonsterPools;
    [SerializeField] Pool[] EffectPools;
    static Dictionary<GameObject, Pool> dictionary;

    private void Awake()
    {
        dictionary = new Dictionary<GameObject, Pool>();
        Initalize(BuffItemPools);
        Initalize(MonsterPools);
        Initalize(EffectPools);
    }

#if UNITY_EDITOR
    private void OnDestroy()
    {
        CheckPoolSize(MonsterPools);
        CheckPoolSize(BuffItemPools);
        CheckPoolSize(EffectPools);
    }
#endif
    void CheckPoolSize(Pool[] pools)
    {
        foreach (var pool in pools)
        {
            if (pool.RuntimeSize > pool.Size)
            {
                Debug.LogWarning(string.Format("pool:{0} has runtime size {1} bigger than its initial size {2}!", pool.Prefab.name, pool.RuntimeSize, pool.Size));
            }
        }
    }

    void Initalize(Pool[] pools)
    {
        foreach(var pool in pools)
        {
#if UNITY_EDITOR
            if (dictionary.ContainsKey(pool.Prefab))
            {
                Debug.LogError("same prefab in multiple pools! Prefab:" + pool.Prefab.name);
                continue;
            }
#endif
            dictionary.Add(pool.Prefab, pool);
            Transform poolParent = new GameObject("Pool:-" + pool.Prefab.name).transform;
            poolParent.parent = transform;
            pool.Initialize(poolParent);
        }
    }

    public static GameObject Release(GameObject prefab)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could Not find Prefab:" + prefab.name);
            return null;
        }
#endif 
        return dictionary[prefab].preparedObject();
    }

    public static GameObject Release(GameObject prefab,Vector3 position)
    {
#if UNITY_EDITOR
        if (!dictionary.ContainsKey(prefab))
        {
            Debug.LogError("Pool Manager could Not find Prefab:" + prefab.name);
            return null;
        }
#endif 
        return dictionary[prefab].preparedObject(position);
    }

    
}
