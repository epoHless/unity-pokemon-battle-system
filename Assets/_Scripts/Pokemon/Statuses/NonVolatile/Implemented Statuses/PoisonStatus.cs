using System.Collections;
using UnityEngine;

public class PoisonStatus : PostTurnNonVolatileStatus
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        yield return NotificationManager.Instance.ShowNotification($"{pokemon.Name} was hurt by poison!");
        manager.GetStatusParticle(manager.PoisonStatus).PlayParticle(pokemon.transform.position);
        yield return new WaitUntil(() => manager.PoisonStatus.Particle.IsDone);
        yield return BattleTween.DealDamagePercentage(pokemon, 12.5f);
    }
}