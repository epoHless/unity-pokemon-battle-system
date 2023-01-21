
using System.Collections;
using UnityEngine;

public static class BattleTween
{
    public static IEnumerator DealDamage(MoveSO moveSo,Pokemon caster, Pokemon target)
    {
        bool IsDone = false;
        
        float startHp = target.battleStats.CurrentPS;

        float crit = Random.Range(1, 13) > 6 ? 1.5f : 1f;
        
        float typeEffectiveness = 0;

        string modifierMessage = null;
        
        foreach (var elementType in target.Types)
        {
            typeEffectiveness += elementType.GetModifier(moveSo.Type).Modifier;
            modifierMessage = elementType.GetModifier(moveSo.Type).ModifierMessage;
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
        }, startHp, newHp, .35f).setOnComplete(() =>
        {
            IsDone = true;
        });

        yield return new WaitUntil(() => IsDone);
        if (modifierMessage != null) yield return NotificationManager.Instance.ShowNotificationCOR(modifierMessage, 1);
        
        if (target.battleStats.CurrentPS <= 0)
        {
            yield return NotificationManager.Instance.ShowNotificationCOR($"{target.Name} Fainted!", 2);
            BattleManager.Instance.OnPokemonFaint?.Invoke(target);
        }
    }

    public static IEnumerator DealDamageIncreased(MoveSO moveSo, Pokemon caster, Pokemon target, float percentageIncrease)
    {
        var move = moveSo;

        move.MultiplyPower(percentageIncrease);
        yield return DealDamage(move, caster, target);
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
        
        if (pokemon.battleStats.CurrentPS <= 0)
        {
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} Fainted!",2);
            BattleManager.Instance.OnPokemonFaint?.Invoke(pokemon);
        }
    }
    
    public static IEnumerator DamageSeededPokemon(Pokemon pokemon, float percentage)
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

        IsDone = false;

        var leecher = pokemon.opponent;

        var newLeechHP = leecher.battleStats.CurrentPS + percentageHp;

        if (newLeechHP >= leecher.battleStats.MaxPS)
        {
            newLeechHP = leecher.battleStats.MaxPS;
        }
        
        LeanTween.value(pokemon.gameObject, f =>
        {
            leecher.battleStats.CurrentPS = f;
        }, leecher.battleStats.CurrentPS, newLeechHP, .35f).setOnComplete(() =>
        {
            IsDone = true;
        });
        
        yield return new WaitUntil((() => IsDone));
        yield return NotificationManager.Instance.ShowNotificationCOR($"{leecher.Name} was cured!", 1.5f);

        
        if (pokemon.battleStats.CurrentPS <= 0)
        {
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} Fainted!", 2);
            BattleManager.Instance.OnPokemonFaint?.Invoke(pokemon);
        }
    }
}