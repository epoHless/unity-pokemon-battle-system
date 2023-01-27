using System.Collections;
using UnityEngine;

public static class Damager
{
    /// <summary>
    /// BAse damage calculation
    /// </summary>
    /// <param name="moveSo"></param>
    /// <param name="caster"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static IEnumerator Damage(MoveSO moveSo,Pokemon caster, Pokemon target)
    {
        bool IsDone = false;
        
        float startHp = target.battleStats.CurrentPS;

        float crit = Random.Range(1, 13) > 6 ? 1.5f : 1f;
        
        float typeEffectiveness = 0;

        string modifierMessage = null;
        
        foreach (var elementType in target.PokemonData.Types)
        {
            typeEffectiveness += elementType.GetModifier(moveSo.Type).Modifier;
            modifierMessage = elementType.GetModifier(moveSo.Type).ModifierMessage;
        }

        float rng = Random.Range(0.85f, 1f);

        float stab = 1;

        foreach (var elementType in caster.PokemonData.Types)
        {
            if (elementType == moveSo.Type)
            {
                stab = 1.5f;
                break;
            }
        }

        float ad = 1;
        
        if (moveSo.moveType == MoveSO.MoveType.SPECIAL) ad = caster.battleStats.GetSAtk() / target.battleStats.GetSDef();
        else if (moveSo.moveType == MoveSO.MoveType.PHYSICAL) ad = caster.battleStats.GetAtk() / target.battleStats.GetDef();
        
        float modifier = crit * typeEffectiveness * stab * rng;

        float damage = (((((2 * caster.PokemonData.Level) / 5) + 2) * moveSo.Power * ad) / 50 + 2) * modifier;
        
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
            yield return NotificationManager.Instance.ShowNotificationCOR($"{target.PokemonData.Name} Fainted!", 2);
            BattleManager.Instance.OnPokemonFaint?.Invoke(target);
        }
    }

    /// <summary>
    /// Deal damage increased.
    /// </summary>
    /// <param name="moveSo"></param>
    /// <param name="caster"></param>
    /// <param name="target"></param>
    /// <param name="percentageIncrease"></param>
    /// <returns></returns>
    public static IEnumerator DamageIncreased(MoveSO moveSo, Pokemon caster, Pokemon target, float percentageIncrease)
    {
        var move = moveSo;

        move.MultiplyPower(percentageIncrease);
        yield return Damage(move, caster, target);
    }
    
    /// <summary>
    /// Deal a percentage of a pokemon health as damage
    /// </summary>
    /// <param name="pokemon"></param>
    /// <param name="percentage"></param>
    /// <returns></returns>
    public static IEnumerator DamagePercentage(Pokemon pokemon, float percentage)
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
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.PokemonData.Name} Fainted!",2);
            BattleManager.Instance.OnPokemonFaint?.Invoke(pokemon);
        }
    }
    
    /// <summary>
    /// Deal a percentage of a pokemon health as damage and heal off it.
    /// </summary>
    /// <param name="pokemon"></param>
    /// <param name="percentage"></param>
    /// <returns></returns>
    public static IEnumerator DamageAndHealOverTurn(Pokemon pokemon, float percentage)
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
        yield return NotificationManager.Instance.ShowNotificationCOR($"{leecher.PokemonData.Name} was cured!", 1.5f);

        
        if (pokemon.battleStats.CurrentPS <= 0)
        {
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.PokemonData.Name} Fainted!", 2);
            BattleManager.Instance.OnPokemonFaint?.Invoke(pokemon);
        }
    }
    
    
    /// <summary>
    /// Deal a percentage of a pokemon health as damage and receive damage for a percentage of the damage dealt.
    /// </summary>
    /// <param name="pokemon"></param>
    /// <param name="percentage"></param>
    /// <returns></returns>
    public static IEnumerator DamageAndRecoil(MoveSO moveSo,Pokemon caster, Pokemon target, float percentage)
    {
        bool IsDone = false;
        
        float startHp = target.battleStats.CurrentPS;

        float crit = Random.Range(1, 13) > 6 ? 1.5f : 1f;
        
        float typeEffectiveness = 0;

        string modifierMessage = null;
        
        foreach (var elementType in target.PokemonData.Types)
        {
            typeEffectiveness += elementType.GetModifier(moveSo.Type).Modifier;
            modifierMessage = elementType.GetModifier(moveSo.Type).ModifierMessage;
        }

        float rng = Random.Range(0.85f, 1f);

        float stab = 1;

        foreach (var elementType in caster.PokemonData.Types)
        {
            if (elementType == moveSo.Type)
            {
                stab = 1.5f;
                break;
            }
        }

        float ad = 1;
        
        if (moveSo.moveType == MoveSO.MoveType.SPECIAL) ad = caster.battleStats.GetSAtk() / target.battleStats.GetSDef();
        else if (moveSo.moveType == MoveSO.MoveType.PHYSICAL) ad = caster.battleStats.GetAtk() / target.battleStats.GetDef();
        
        float modifier = crit * typeEffectiveness * stab * rng;

        float damage = (((((2 * caster.PokemonData.Level) / 5) + 2) * moveSo.Power * ad) / 50 + 2) * modifier;
        
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

        IsDone = false;

        var percentageDamage = damage * percentage;
        
        var opponent = target.opponent;
        
        var opponentHP = opponent.battleStats.CurrentPS - percentageDamage;

        if (opponentHP <= 0)
        {
            opponentHP = 0;
        }
        
        LeanTween.value(target.gameObject, f =>
        {
            opponent.battleStats.CurrentPS = f;
        }, opponent.battleStats.CurrentPS, opponentHP, .35f).setOnComplete(() =>
        {
            IsDone = true;
        });
        
        yield return new WaitUntil((() => IsDone));
        yield return NotificationManager.Instance.ShowNotificationCOR($"{opponent.PokemonData.Name} was hit by the recoil!", 1.5f);

        
        if (target.battleStats.CurrentPS <= 0)
        {
            yield return NotificationManager.Instance.ShowNotificationCOR($"{target.PokemonData.Name} Fainted!", 2);
            BattleManager.Instance.OnPokemonFaint?.Invoke(target);
        }
        
        if (opponent.battleStats.CurrentPS <= 0)
        {
            yield return NotificationManager.Instance.ShowNotificationCOR($"{opponent.PokemonData.Name} Fainted!", 2);
            BattleManager.Instance.OnPokemonFaint?.Invoke(target);
        }
    }

    public static IEnumerator DamageAndLeech(MoveSO moveSo,Pokemon caster, Pokemon target, float percentage)
    {
        bool IsDone = false;
        
        float startHp = target.battleStats.CurrentPS;

        float crit = Random.Range(1, 13) > 6 ? 1.5f : 1f;
        
        float typeEffectiveness = 0;

        string modifierMessage = null;
        
        foreach (var elementType in target.PokemonData.Types)
        {
            typeEffectiveness += elementType.GetModifier(moveSo.Type).Modifier;
            modifierMessage = elementType.GetModifier(moveSo.Type).ModifierMessage;
        }

        float rng = Random.Range(0.85f, 1f);

        float stab = 1;

        foreach (var elementType in caster.PokemonData.Types)
        {
            if (elementType == moveSo.Type)
            {
                stab = 1.5f;
                break;
            }
        }

        float ad = 1;
        
        if (moveSo.moveType == MoveSO.MoveType.SPECIAL) ad = caster.battleStats.GetSAtk() / target.battleStats.GetSDef();
        else if (moveSo.moveType == MoveSO.MoveType.PHYSICAL) ad = caster.battleStats.GetAtk() / target.battleStats.GetDef();
        
        float modifier = crit * typeEffectiveness * stab * rng;

        float damage = (((((2 * caster.PokemonData.Level) / 5) + 2) * moveSo.Power * ad) / 50 + 2) * modifier;
        
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

        IsDone = false;

        var percentageDamage = damage * percentage;
        
        var leecher = target.opponent;
        
        var newLeechHP = leecher.battleStats.CurrentPS + percentageDamage;

        if (newLeechHP >= leecher.battleStats.MaxPS)
        {
            newLeechHP = leecher.battleStats.MaxPS;
        }
        
        LeanTween.value(target.gameObject, f =>
        {
            leecher.battleStats.CurrentPS = f;
        }, leecher.battleStats.CurrentPS, newLeechHP, .35f).setOnComplete(() =>
        {
            IsDone = true;
        });
        
        yield return new WaitUntil((() => IsDone));
        yield return NotificationManager.Instance.ShowNotificationCOR($"{leecher.PokemonData.Name} was cured!", 1.5f);

        
        if (target.battleStats.CurrentPS <= 0)
        {
            yield return NotificationManager.Instance.ShowNotificationCOR($"{target.PokemonData.Name} Fainted!", 2);
            BattleManager.Instance.OnPokemonFaint?.Invoke(target);
        }
        
    }
}