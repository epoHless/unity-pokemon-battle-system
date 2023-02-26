using System;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Tile", menuName = "Tilemap/Grass")]
public class GrassTile : RuleTile
{
    [Header("Custom Data")] [field: SerializeField, SORender]
    public EncounterData EncounterData;
    
    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);
    }
}