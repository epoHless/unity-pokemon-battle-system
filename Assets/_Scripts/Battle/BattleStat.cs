using System;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class BattleStat
{
    public float Value;
    private float _initialValue;
    
    public int Stage = 0;
    private float[] positiveModifier = { 0, .5f, 1f, 1.5f, 2f, 2.5f, 3f };
    private float[] negativeModifier = { 0, .333f, .5f, .6f, .666f, .715f, .75f };

    public static event Action OnBuff;
    public static event Action OnDeBuff;

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
            OnBuff?.Invoke();
        }
    }
    
    public IEnumerator DecreaseStat(Pokemon pokemon)
    {
        if (Stage <= -6) MobileFramework.Analytics.Logging.Warning($"Stat {ToString()} is minimized already!", Color.red);
        else
        {
            Stage--;
            AdjustStat();
            // OnDeBuff?.Invoke();
            yield return GameObject.FindObjectOfType<DeBuffParticle>().ShowDecrease(pokemon);
        }
    }

    private void AdjustStat()
    {
        Value = Stage > 0 ? _initialValue + (_initialValue * positiveModifier[Mathf.Abs(Stage)]) : _initialValue - (_initialValue * negativeModifier[Mathf.Abs(Stage)]);
    }
}