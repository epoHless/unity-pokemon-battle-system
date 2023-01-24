
using System.Collections.Generic;

[System.Serializable]
public class BattleModifier
{
    public float MaxPS;
    public float CurrentPS;

    public List<BattleStat> battleStats;

    public BattleModifier(PermanentStatistic statistic)
    {
        MaxPS = statistic.PS;
        CurrentPS = MaxPS;

        battleStats = new List<BattleStat>()
        {
            new BattleStat("ATK", statistic.ATK),
            new BattleStat("SPATK", statistic.SPATK),
            new BattleStat("DEF", statistic.DEF),
            new BattleStat("SPDEF", statistic.SPDEF),
            new BattleStat("SPD", statistic.SPD)
        };
    }

    public float GetAtk()
    {
        return battleStats.Find(stat => stat.Name == "ATK").Value;
    }
    
    public float GetSAtk()
    {
        return battleStats.Find(stat => stat.Name == "SPATK").Value;
    }
    
    public float GetDef()
    {
        return battleStats.Find(stat => stat.Name == "DEF").Value;
    }
    
    public float GetSDef()
    {
        return battleStats.Find(stat => stat.Name == "SPDEF").Value;
    }
    
    public float GetSpeed()
    {
        return battleStats.Find(stat => stat.Name == "SPD").Value;
    }
}