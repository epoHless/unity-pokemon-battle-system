
using System.Collections;
using UnityEngine;

public class BurnStatus : PostTurnNonVolatileStatus
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        yield return NotificationManager.Instance.ShowNotification($"{pokemon.Name} was hurt by it's burn!");
        manager.GetBurnParticle().PlayParticle(pokemon.transform.position);
        yield return new WaitUntil(() => manager.GetBurnParticle().IsDone);
        yield return BattleTween.DealDamagePercentage(pokemon, 12.5f);
    }
}

