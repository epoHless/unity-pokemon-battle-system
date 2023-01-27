using System;
using System.Collections;

public class ChangeStatBlock : MoveBlock
{
    public enum Stat
    {
        ATK,
        SPATK,
        DEF,
        SPDEF,
        SPD
    }
    
    public enum StatModifierType
    {
        INCREASE,
        SHARPLY_INCREASE,
        DECREASE,
        HARSHLY_DECREASE
    }

    public Stat Statistic;
    public StatModifierType modifierType;
    private string statMessage;

    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        statMessage = Statistic.ToString();
        
        foreach (var stat in afflictedPokemon.battleStats.battleStats)
        {
            if (stat.Name == Statistic.ToString())
            {
                switch (modifierType)
                {
                    case StatModifierType.INCREASE:
                        yield return stat.IncreaseStat(afflictedPokemon, statMessage);
                        break;
                    case StatModifierType.SHARPLY_INCREASE:
                        yield return stat.SharplyIncreaseStat(afflictedPokemon, statMessage);
                        break;
                    case StatModifierType.DECREASE:
                        yield return stat.DecreaseStat(afflictedPokemon, statMessage);
                        break;
                    case StatModifierType.HARSHLY_DECREASE:
                        yield return stat.HarshlyDecreaseStat(afflictedPokemon, statMessage);
                        break;
                }
            }
        }
        
    }
}

