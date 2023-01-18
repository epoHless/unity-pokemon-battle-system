
[System.Serializable]
public class BattleModifier
{
    public float PS;
    public BattleStat ATK;
    public BattleStat SPATK;
    public BattleStat DEF;
    public BattleStat SPDEF;
    public BattleStat SPD;

    public BattleModifier(PermanentStatistic statistic)
    {
        PS = statistic.PS;
        ATK = new BattleStat(statistic.ATK);
        SPATK = new BattleStat(statistic.SPATK);
        DEF = new BattleStat(statistic.DEF);
        SPDEF = new BattleStat(statistic.SPDEF);
        SPD = new BattleStat(statistic.SPD);
    }
}

