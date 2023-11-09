using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Threes : MonoBehaviour
{
    public Tilemap treeTilemap;
    public TilemapManager tilemapManager;

    public float burnProbability = 0.5f;

    void Start()
    {
        BurnRandomTrees();
    }

    void BurnRandomTrees()
    {
        BoundsInt bounds = treeTilemap.cellBounds;

        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            if (Random.value < burnProbability)
            {
                tilemapManager.PutOnFire(pos);
            }
        }
    }
}
