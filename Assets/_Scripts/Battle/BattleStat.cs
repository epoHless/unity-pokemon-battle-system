using UnityEngine;

[System.Serializable]
public class BattleStat
{
    public float Value;
    private float _initialValue;
    
    public int Stage;
    private float[] positiveModifier = { 0, .5f, 1f, 1.5f, 2f, 2.5f, 3f };
    private float[] negativeModifier = { 0, .333f, .5f, .6f, .666f, .715f, .75f };
    
    public BattleStat(float value)
    {
        Value = value;
        _initialValue = value;
    }

    public void IncreaseStat()
    {
        if (Stage >= 6) MobileFramework.Analytics.Logging.Warning($"Stat {ToString()} is maxed out already!", Color.red);
        else
        {
            Stage++;
            AdjustStat();
        }
    }
    
    public void DecreaseStat()
    {
        if (Stage <= 6) MobileFramework.Analytics.Logging.Warning($"Stat {ToString()} is minimized already!", Color.red);
        else
        {
            Stage++;
            AdjustStat();
        }
    }

    private void AdjustStat()
    {
        Value = Stage > 0 ? _initialValue + (_initialValue * positiveModifier[Mathf.Abs(Stage)]) : _initialValue - (_initialValue * negativeModifier[Mathf.Abs(Stage)]);
    }
}

