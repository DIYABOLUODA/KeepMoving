using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LastMap : MonoBehaviour
{
    [SerializeField] Tilemap[] allMaps; // 包含所有Tilemap的数组
    List<KeyValuePair<Tilemap, Vector3Int>> tiles; // 用于存储所有Tile及其对应的Tilemap

    private void Awake()
    {
        tiles = new List<KeyValuePair<Tilemap, Vector3Int>>();
    }

    private void OnEnable()
    {
        tiles.Clear();
        foreach (Tilemap tilemap in allMaps)
        {
            for (int x = tilemap.cellBounds.xMin; x < tilemap.cellBounds.xMax; x++)
            {
                for (int y = tilemap.cellBounds.yMin; y < tilemap.cellBounds.yMax; y++)
                {
                    for (int z = tilemap.cellBounds.zMin; z < tilemap.cellBounds.zMax; z++)
                    {
                        Vector3Int position = new Vector3Int(x, y, z);
                        if (tilemap.HasTile(position))
                        {
                            tiles.Add(new KeyValuePair<Tilemap, Vector3Int>(tilemap, position)); // 将Tile及其对应的Tilemap添加到集合
                        }
                    }
                }
            }
        }
    }

  
  void OnTriggerEnter2D(Collider2D other)
  {
      if(other.CompareTag("PlayerTrigger")){
        StartCoroutine(DisableRandomTilePeriodically());
      }
  }

    private IEnumerator DisableRandomTilePeriodically()
    {
        while (tiles.Count > 0)
        {
            yield return new WaitForSeconds(0.01f); 
            DisableRandomTile();
        }
    }

    private void DisableRandomTile()
    {
        if (tiles.Count == 0) return;

        int randomIndex = Random.Range(0, tiles.Count);
        KeyValuePair<Tilemap, Vector3Int> tilePair = tiles[randomIndex];
        tilePair.Key.SetTile(tilePair.Value, null); 
        tiles.RemoveAt(randomIndex); 
    }
}
