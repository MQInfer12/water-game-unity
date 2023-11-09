using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    public Tilemap treeTilemap;
    public Tilemap burningTilemap;
    public Tilemap fireTilemap;
    public TileBase threeTile1;
    public TileBase threeTile2;
    public TileBase threeTile3;
    public TileBase burningTile1;
    public TileBase burningTile2;
    public TileBase burningTile3;
    public TileBase fireTile;

    public void PutOnFire(Vector3Int position)
    {
        TileBase treeTile = treeTilemap.GetTile(position);
        if (treeTile != null) {
            if(treeTile == threeTile1) {
                burningTilemap.SetTile(position, burningTile1);
            }
            if(treeTile == threeTile2) {
                burningTilemap.SetTile(position, burningTile2);
            }
            if(treeTile == threeTile3) {
                burningTilemap.SetTile(position, burningTile3);
            }
            fireTilemap.SetTile(position, fireTile);
        }
    }

    public void PutOffFire(Vector3 position)
    {
        Vector3Int cellPosition = burningTilemap.WorldToCell(position);
        burningTilemap.SetTile(cellPosition, null);
        fireTilemap.SetTile(cellPosition, null);
    }

    public int FireCount()
    {
        BoundsInt bounds = fireTilemap.cellBounds;
        int contadorTiles = 0;

        foreach (Vector3Int posicion in bounds.allPositionsWithin)
        {
            if (fireTilemap.HasTile(posicion))
            {
                contadorTiles++;
            }
        }
        return contadorTiles;
    }
}
