using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Tile", menuName = "Tilemap/Custom")]
public class CustomRuleTile : RuleTile
{
   public Color Color = Color.white;
   public int WalkCost = 1;

   public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
   {
      base.GetTileData(position, tilemap, ref tileData);

      tileData.color = Color;
      tileData.flags = TileFlags.LockColor;
   }
}
