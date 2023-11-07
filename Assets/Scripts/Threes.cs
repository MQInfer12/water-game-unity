using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Threes : MonoBehaviour
{
    public Tilemap treeTilemap;
    public Tilemap burnedTreeTilemap;
    public TileBase burningTile;
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
                TileBase treeTile = treeTilemap.GetTile(pos);
                if (treeTile != null)
                {
                    burnedTreeTilemap.SetTile(pos, burningTile);
                }
            }
        }
    }
}
