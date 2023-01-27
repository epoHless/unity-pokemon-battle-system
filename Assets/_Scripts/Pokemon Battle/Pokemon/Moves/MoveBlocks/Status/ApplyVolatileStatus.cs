using System.Collections;
using MobileFramework.Subclass;
using UnityEngine;

public class ApplyVolatileStatus : ApplyStatusBlock
{
    [Range(0, 100)] public int Probability;
    public StatusInfo statusInfo; 
    
    private MoveParticle spawnedParticle;

    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        if (afflictedPokemon.IsFainted) yield break;

        bool CanApply = Random.Range(1, 101) <= Probability;

        if (CanApply)
        {
            if(StatusManager.Instance.HasStatus(afflictedPokemon, statusInfo.status))
            {
                yield return NotificationManager.Instance.ShowNotificationCOR($"{statusInfo.Name} has failed!");
            }
            else
            {
                if (!spawnedParticle) spawnedParticle = GameObject.Instantiate(statusInfo.Particle);
                
                statusInfo.status = SubclassUtility.GetSubclassFromIndex<Status>(statusInfo.Status);
                statusInfo.status.Particle = spawnedParticle;
                
                yield return StatusManager.Instance.ApplyVolatileStatus(afflictedPokemon, statusInfo, spawnedParticle);
            }
        }
    }
}