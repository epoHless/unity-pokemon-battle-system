
using System.Collections;
using UnityEngine;

public static class BattleTween
{
    public static void DealDamage(MoveSO moveSo,Pokemon caster, Pokemon target)
    {
        float startHp = target.battleStats.CurrentPS;

        float crit = Random.Range(1, 13) > 6 ? 1.5f : 1f;
        
        float typeEffectiveness = 0;

        foreach (var elementType in target.Types)
        {
            typeEffectiveness += moveSo.Type.GetModifier(elementType);
        }

        float rng = Random.Range(0.85f, 1f);

        float stab = 1;

        foreach (var elementType in caster.Types)
        {
            if (elementType == moveSo.Type)
            {
                stab = 1.5f;
                break;
            }
        }

        float ad = 1;
        if (moveSo.moveType == MoveSO.MoveType.SPECIAL) ad = caster.battleStats.SPATK.Value / target.battleStats.SPDEF.Value;
        else if (moveSo.moveType == MoveSO.MoveType.PHYSICAL) ad = caster.battleStats.ATK.Value / target.battleStats.DEF.Value;
        
        float modifier = crit * typeEffectiveness * stab * rng;

        float damage = (((((2 * caster.Level) / 5) + 2) * moveSo.Power * ad) / 50 + 2) * modifier;
        
        float newHp = target.battleStats.CurrentPS - damage;

        LeanTween.value(target.gameObject, f =>
        {
            target.battleStats.CurrentPS = f;
        }, startHp, newHp, .35f);
    }
    
    public static IEnumerator DealDamagePercentage(Pokemon pokemon, float percentage)
    {
        bool IsDone = false;
        
        float startHp = pokemon.battleStats.CurrentPS;
        float percentageHp = pokemon.battleStats.MaxPS / percentage;

        float newHp = pokemon.battleStats.CurrentPS - percentageHp;

        LeanTween.value(pokemon.gameObject, f =>
        {
            pokemon.battleStats.CurrentPS = f;
        }, startHp, newHp, .35f).setOnComplete(() =>
        {
            IsDone = true;
        });

        yield return new WaitUntil((() => IsDone));
    }
}

