using System.Collections;
using UnityEngine;

public class Seeded : PostTurnVolatileStatus
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} was hurt by the leeching!");
        manager.GetStatusParticle(manager.SeededStatus).PlayParticle(pokemon.transform.position);
        yield return new WaitUntil(() => manager.SeededStatus.Particle.IsDone);
        yield return BattleTween.DamageSeededPokemon(pokemon, 12.5f);
    }
}