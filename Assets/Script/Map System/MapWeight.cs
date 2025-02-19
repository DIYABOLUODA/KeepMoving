using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapWeight : MonoBehaviour,IMapSize
{
     [SerializeField] Tilemap tilemap;
       public float weight;
    public GameObject prefab;
    public float ReturnLength()
    {
       // Debug.Log("长度"+tilemap.size.x);
       return tilemap.size.x;
       
      
    }

    public float ReturnWeidth()
    {
        return tilemap.size.y;
        
    }
}
