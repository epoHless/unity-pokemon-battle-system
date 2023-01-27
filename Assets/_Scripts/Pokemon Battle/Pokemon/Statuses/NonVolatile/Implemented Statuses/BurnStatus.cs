using System.Collections;
using UnityEngine;

public class BurnStatus : PostTurnNonVolatileStatus
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.PokemonData.Name} was hurt by it's burn!",1.5f);
        yield return Particle.PlayParticle(pokemon.transform.position);
        yield return Damager.DamagePercentage(pokemon, 12.5f);
    }
}