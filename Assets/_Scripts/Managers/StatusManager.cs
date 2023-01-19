using System.Collections.Generic;
using System.Linq;
using MobileFramework.Subclass;
using UnityEngine;

public class StatusManager : Singleton<StatusManager>
{
    [field: SerializeField] public StatusInfo BurnStatus;
    [field: SerializeField] public StatusInfo PoisonStatus;
    [field: SerializeField] public StatusInfo ParalyseStatus;

    [SerializeField] private List<MoveParticle> statusParticles;
    public MoveParticle currentParticle { get; private set; }

    public void AddNonVolatileStatus(Pokemon pokemon, StatusInfo statusInfo)
    {
        statusInfo.status = SubclassUtility.GetSubclassFromIndex<Status>(statusInfo.Status);

        if (statusInfo.status is NonVolatileStatus && !pokemon.statuses.OfType<NonVolatileStatus>().Any())
        {
            pokemon.ui.SetStateIcon(statusInfo.Sprite);
            pokemon.statuses.Add(statusInfo.status);
        }
    }

    public void ApplyBurn(Pokemon pokemon)
    {
        AddNonVolatileStatus(pokemon, BurnStatus);
    }
    
    public void ApplyPoison(Pokemon pokemon)
    {
        AddNonVolatileStatus(pokemon, PoisonStatus);
    }
    
    public void ApplyParalyse(Pokemon pokemon)
    {
        AddNonVolatileStatus(pokemon, ParalyseStatus);
    }

    public MoveParticle GetStatusParticle(StatusInfo statusInfo)
    {
        currentParticle = statusParticles.Find(particle => particle == statusInfo.Particle);
        return currentParticle;
    }
}

