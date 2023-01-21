using System.Collections;
using System.Linq;
using MobileFramework.Subclass;
using UnityEngine;

public class StatusManager : Singleton<StatusManager>
{
    [field: SerializeField] public StatusInfo BurnStatus;
    [field: SerializeField] public StatusInfo PoisonStatus;
    [field: SerializeField] public StatusInfo ParalyseStatus;
    [field: SerializeField] public StatusInfo FrozenStatus;
    [field: SerializeField] public StatusInfo SeededStatus;

    public bool AddNonVolatileStatus(Pokemon pokemon, StatusInfo statusInfo)
    {
        statusInfo.status = SubclassUtility.GetSubclassFromIndex<Status>(statusInfo.Status);

        if (statusInfo.status is NonVolatileStatus && !pokemon.statuses.OfType<NonVolatileStatus>().Any())
        {
            pokemon.ui.SetStateIcon(statusInfo.Sprite);
            pokemon.statuses.Add(statusInfo.status);
            return true;
        }

        return false;
    }
    
    public bool AddVolatileStatus(Pokemon pokemon, StatusInfo statusInfo)
    {
        statusInfo.status = SubclassUtility.GetSubclassFromIndex<Status>(statusInfo.Status);

        if (statusInfo.status is VolatileStatus && !pokemon.statuses.Contains(statusInfo.status))
        {
            pokemon.statuses.Add(statusInfo.status);
            return true;
        }

        return false;
    }
    

    #region NON VOLATILE STATUSES

    public IEnumerator ApplyBurn(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, BurnStatus))
        {
            yield return GetStatusParticle(BurnStatus).PlayParticle(pokemon.transform.position);
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.PokemonData.Name} was burned!", 1.5f);
        }
    }
    
    public IEnumerator ApplyPoison(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, PoisonStatus))
        {
            yield return GetStatusParticle(PoisonStatus).PlayParticle(pokemon.transform.position);
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.PokemonData.Name} was poisoned!",1.5f);
        }
    }
    
    public IEnumerator ApplyParalyse(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, ParalyseStatus))
        {
            yield return GetStatusParticle(ParalyseStatus).PlayParticle(pokemon.transform.position);
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.PokemonData.Name} was paralysed!",1.5f);
        }
    }
    
    public IEnumerator ApplyFreeze(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, FrozenStatus))
        {
            yield return GetStatusParticle(FrozenStatus).PlayParticle(pokemon.transform.position);
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.PokemonData.Name} was frozen solid!",1.5f);
        }
    }

    #endregion
    
    #region NON VOLATILE STATUS CHECK

    public bool IsParalysed(Pokemon pokemon)
    {
        return pokemon.statuses.Contains(ParalyseStatus.status);
    }
    
    public bool IsBurned(Pokemon pokemon)
    {
        return pokemon.statuses.Contains(BurnStatus.status);
    }
    
    public bool IsFrozen(Pokemon pokemon)
    {
        return pokemon.statuses.Contains(FrozenStatus.status);
    }
    
    public bool IsPoisoned(Pokemon pokemon)
    {
        return pokemon.statuses.Contains(PoisonStatus.status);
    }

    #endregion

    #region VOLATILE STATUSES

    public IEnumerator ApplySeed(Pokemon pokemon)
    {
        if (AddVolatileStatus(pokemon, SeededStatus))
        {
            yield return GetStatusParticle(SeededStatus).PlayParticle(pokemon.transform.position);
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.PokemonData.Name} was planted a seed on!",1.5f);
        }
    }
    
    public bool IsSeeded(Pokemon pokemon)
    {
        return pokemon.statuses.Contains(SeededStatus.status);
    }

    #endregion

    public MoveParticle GetStatusParticle(StatusInfo statusInfo)
    {
        return statusInfo.Particle;
    }
}

