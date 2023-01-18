using System;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon : MonoBehaviour
{
    public enum Gender
    {
        NULL,
        MALE,
        FEMALE
    }
    
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Gender gender { get; private set; }
    [field: SerializeField] public List<ElementType> Types { get; private set; }
    [field: SerializeField] public PermanentStatistic PermanentStatistic { get; private set; }
    [field: SerializeField] public List<Move> Moves { get; private set; }

    public BattleModifier battleStats;

    public Pokemon opponent { get; private set; }
    
    private void Awake()
    {
        battleStats = new BattleModifier(PermanentStatistic);
        opponent = BattleManager.Instance.GetTarget(this);
    }

    public BattleModifier GetCurrentStats()
    {
        return battleStats;
    }
}