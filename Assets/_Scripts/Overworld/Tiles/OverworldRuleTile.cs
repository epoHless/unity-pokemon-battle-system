using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Tile", menuName = "Tilemap/Overwold")]
public class OverworldRuleTile : RuleTile
{
   public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
   {
      base.GetTileData(position, tilemap, ref tileData);
   }
}
