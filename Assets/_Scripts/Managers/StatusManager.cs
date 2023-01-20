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

    public IEnumerator ApplyBurn(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, BurnStatus))
        {
            GetStatusParticle(BurnStatus).PlayParticle(pokemon.transform.position);
            yield return new WaitUntil(() => BurnStatus.Particle.IsDone);
            yield return NotificationManager.Instance.ShowNotification($"{pokemon.Name} was burned!");
        }
    }
    
    public IEnumerator ApplyPoison(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, PoisonStatus))
        {
            GetStatusParticle(PoisonStatus).PlayParticle(pokemon.transform.position);
            yield return new WaitUntil(() => PoisonStatus.Particle.IsDone);
            yield return NotificationManager.Instance.ShowNotification($"{pokemon.Name} was poisoned!");
        }
    }
    
    public IEnumerator ApplyParalyse(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, ParalyseStatus))
        {
            GetStatusParticle(ParalyseStatus).PlayParticle(pokemon.transform.position);
            yield return new WaitUntil(() => ParalyseStatus.Particle.IsDone);
            yield return NotificationManager.Instance.ShowNotification($"{pokemon.Name} was paralysed!");
        }
    }
    
    public IEnumerator ApplyFreeze(Pokemon pokemon)
    {
        if (AddNonVolatileStatus(pokemon, FrozenStatus))
        {
            GetStatusParticle(FrozenStatus).PlayParticle(pokemon.transform.position);
            yield return new WaitUntil(() => FrozenStatus.Particle.IsDone);
            yield return NotificationManager.Instance.ShowNotification($"{pokemon.Name} was frozen solid!");
        }
    }

    public MoveParticle GetStatusParticle(StatusInfo statusInfo)
    {
        return statusInfo.Particle;
    }
}

