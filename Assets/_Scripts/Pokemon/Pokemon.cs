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

    private void Awake()
    {
        battleStats = new BattleModifier(PermanentStatistic);
    }

    private void Start()
    {
        SelectMove(0);
    }

    public void SelectMove(int i)
    {
        Moves[i].ExecuteMove(this);
    }

    public BattleModifier GetCurrentStats()
    {
        return battleStats;
    }
}

