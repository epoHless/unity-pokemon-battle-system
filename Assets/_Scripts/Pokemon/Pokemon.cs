using System;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    [field: SerializeField] public PokemonData PokemonData { get; private set; }
    [field: SerializeField] public List<Move> Moves { get; private set; }
    [field: SerializeField] public PermanentStatistic PermanentStatistic { get; private set; }

    public BattleModifier battleStats;

    [field: SerializeField] public List<Status> statuses;

    public PokemonUI ui { get; private set; }
    
    [field: SerializeField] public Pokemon opponent { get; private set; }

    public bool CanAttack = true;
    public bool IsFainted = false;
    
    private void Awake()
    {
        battleStats = new BattleModifier(PermanentStatistic);
        
        ui = GetComponentInChildren<PokemonUI>();

        foreach (var move in Moves)
        {
            move.SetPP();
        }
        
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