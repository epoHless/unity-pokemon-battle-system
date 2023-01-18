
[System.Serializable]
public class BattleModifier
{
    public float MaxPS;
    public float CurrentPS;
    public BattleStat ATK;
    public BattleStat SPATK;
    public BattleStat DEF;
    public BattleStat SPDEF;
    public BattleStat SPD;

    public BattleModifier(PermanentStatistic statistic)
    {
        MaxPS = statistic.PS;
        CurrentPS = MaxPS;
        ATK = new BattleStat(statistic.ATK);
        SPATK = new BattleStat(statistic.SPATK);
        DEF = new BattleStat(statistic.DEF);
        SPDEF = new BattleStat(statistic.SPDEF);
        SPD = new BattleStat(statistic.SPD);
    }
}