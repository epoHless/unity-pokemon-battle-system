using System;
using System.Collections;
using UnityEngine;

[System.Serializable]
public class BattleStat
{
    public float Value;
    private float _initialValue;
    
    public int Stage = 0;
    private float[] positiveModifier = { 1, 1.5f, 2f, 2.5f, 3f, 3.5f, 4f };
    private float[] negativeModifier = { 1, 1.333f, 1.5f, 1.6f, 1.666f, 1.715f, 1.75f };

    public static event Action<Pokemon> OnBuff;
    public static event Action<Pokemon> OnDeBuff;

    public BattleStat(float value)
    {
        Value = value;
        _initialValue = value;
    }

    public IEnumerator IncreaseStat(Pokemon pokemon, string stat)
    {
        if (Stage >= 6)
        {
            Stage = 6;
            yield return ShowPanel($"Stat is already maxed!");
        }
        else
        {
            Stage++;
            AdjustStat();
            OnBuff?.Invoke(pokemon);
            yield return ShowPanel($"{pokemon.PokemonData.Name}'s {stat} was increased!");
        }
    }
    
    public IEnumerator SharplyIncreaseStat(Pokemon pokemon, string stat)
    {
        if (Stage >= 6)
        {
            Stage = 6;
            yield return ShowPanel($"Stat is already maxed!");
        }
        else
        {
            Stage+=2;
            AdjustStat();
            OnBuff?.Invoke(pokemon);
            yield return ShowPanel($"{pokemon.PokemonData.Name}'s {stat} was sharply increased!");
        }
    }
    
    public IEnumerator DecreaseStat(Pokemon pokemon, string stat)
    {
        if (Stage <= -6)
        {
            Stage = -6;
            yield return ShowPanel($"Stat is already down!");
        }
        else
        {
            Stage--;
            AdjustStat();
            OnDeBuff?.Invoke(pokemon);
            yield return ShowPanel($"{pokemon.PokemonData.Name}'s {stat} was lowered!");
        }
    }
    
    public IEnumerator HarshlyDecreaseStat(Pokemon pokemon, string stat)
    {
        if (Stage <= -6)
        {
            Stage = -6;
            yield return ShowPanel($"Stat is already down!");
        }
        else
        {
            Stage-=2;
            AdjustStat();
            OnDeBuff?.Invoke(pokemon);
            yield return ShowPanel($"{pokemon.PokemonData.Name}'s {stat} was harshly lowered!");
        }
    }

    private void AdjustStat()
    {
        Value = Stage > 0 ? _initialValue + (_initialValue * (1 - positiveModifier[Mathf.Abs(Stage)])) : _initialValue - (_initialValue * (1 - negativeModifier[Mathf.Abs(Stage)]));
    }

    IEnumerator ShowPanel(string message)
    {
        yield return NotificationManager.Instance.ShowNotificationCOR(message, 1);
    }

    public float GetModifierValue()
    {
        return Stage > 0 ? positiveModifier[Stage] : negativeModifier[Stage];
    }
}