using System.Collections;
using UnityEngine;

public class PoisonStatus : PostTurnNonVolatileStatus
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} was hurt by poison!",1.5f);
        yield return manager.GetStatusParticle(manager.PoisonStatus).PlayParticle(pokemon.transform.position);
        yield return BattleTween.DealDamagePercentage(pokemon, 12.5f);
    }
}