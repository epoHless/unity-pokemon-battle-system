﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    [field: SerializeField] public PokemonData PokemonData { get; private set; }
    [field: SerializeField] public PermanentStatistic PermanentStatistic { get; private set; }
    [field: SerializeField] public List<Move> Moves { get; private set; }

    public BattleModifier battleStats;

    [HideInInspector] public List<Status> statuses;

    public PokemonUI ui { get; private set; }
    
    public Pokemon opponent { get; private set; }

    [HideInInspector]
    public bool CanAttack = true;
    [HideInInspector]
    public bool IsFainted = false;
    
    private void Awake()
    {
        battleStats = new BattleModifier(PermanentStatistic);
        
        ui = GetComponentInChildren<PokemonUI>();

        foreach (var move in Moves)
        {
            move.SetPP();
        }
        
        gameObject.transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
    }

    public void SetOpponent()
    {
        opponent = BattleManager.Instance.GetOpponent(this);
    }
    
    public BattleModifier GetCurrentStats()
    {
        return battleStats;
    }
}