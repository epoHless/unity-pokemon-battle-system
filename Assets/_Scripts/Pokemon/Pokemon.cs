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

    public Pokemon opponent { get; private set; }
    
    private void Awake()
    {
        battleStats = new BattleModifier(PermanentStatistic);
        opponent = BattleManager.Instance.GetTarget(this);

        foreach (var move in Moves)
        {
            move.SetPP();
        }
        
        StatusManager.Instance.AddPostTurnNonVolatileStatus(this, new BurnStatus());
    }

    public BattleModifier GetCurrentStats()
    {
        return battleStats;
    }
}