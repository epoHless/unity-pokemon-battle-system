using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap), typeof(TilemapCollider2D))]
public class EncounterManager : MonoBehaviour
{
    private Tilemap tilemap;

    public bool IsInGrass;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    protected void OnEnable()
    {
        PlayerMovement.OnMovementFinished += RollEncounter;
    }

    private void RollEncounter(Vector2 obj)
    {
        if (!IsInGrass) return;
        
        var cellPosition = tilemap.WorldToCell(PlayerMovement.TargetPosition);
        var tile = tilemap.GetTile<GrassTile>(cellPosition);

        if (tile)
        {
            Debug.Log($"{tile.EncounterData.RollEncounter()}");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IsInGrass = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            IsInGrass = false;
        }
    }
}
