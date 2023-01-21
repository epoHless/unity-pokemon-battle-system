using System;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public enum Gender
    {
        MALE,
        FEMALE
    }
    
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int Level { get; private set; }
    [field: SerializeField] public Gender gender { get; private set; }
    [field: SerializeField] public List<ElementType> Types { get; private set; }
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