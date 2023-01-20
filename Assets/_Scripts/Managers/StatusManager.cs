using System.Collections;
using System.Collections.Generic;
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
    
    public IEnumerator ApplySeed(Pokemon pokemon)
    {
        if (AddVolatileStatus(pokemon, SeededStatus))
        {
            GetStatusParticle(SeededStatus).PlayParticle(pokemon.transform.position);
            yield return new WaitUntil(() => SeededStatus.Particle.IsDone);
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} was planted a seed on!");
        }
    }

    public IEnumerator ApplyBurn(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, BurnStatus))
        {
            GetStatusParticle(BurnStatus).PlayParticle(pokemon.transform.position);
            yield return new WaitUntil(() => BurnStatus.Particle.IsDone);
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} was burned!");
        }
    }
    
    public IEnumerator ApplyPoison(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, PoisonStatus))
        {
            GetStatusParticle(PoisonStatus).PlayParticle(pokemon.transform.position);
            yield return new WaitUntil(() => PoisonStatus.Particle.IsDone);
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} was poisoned!");
        }
    }
    
    public IEnumerator ApplyParalyse(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, ParalyseStatus))
        {
            GetStatusParticle(ParalyseStatus).PlayParticle(pokemon.transform.position);
            yield return new WaitUntil(() => ParalyseStatus.Particle.IsDone);
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} was paralysed!");
        }
    }
    
    public IEnumerator ApplyFreeze(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, FrozenStatus))
        {
            GetStatusParticle(FrozenStatus).PlayParticle(pokemon.transform.position);
            yield return new WaitUntil(() => FrozenStatus.Particle.IsDone);
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} was frozen solid!");
        }
    }

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

    public MoveParticle GetStatusParticle(StatusInfo statusInfo)
    {
        return statusInfo.Particle;
    }
}

