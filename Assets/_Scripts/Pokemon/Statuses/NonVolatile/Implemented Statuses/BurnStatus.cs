﻿using System.Collections;
using UnityEngine;

public class BurnStatus : PostTurnNonVolatileStatus
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} was hurt by it's burn!");
        manager.GetStatusParticle(manager.BurnStatus).PlayParticle(pokemon.transform.position);
        yield return new WaitUntil(() => manager.BurnStatus.Particle.IsDone);
        yield return BattleTween.DealDamagePercentage(pokemon, 12.5f);
    }
}