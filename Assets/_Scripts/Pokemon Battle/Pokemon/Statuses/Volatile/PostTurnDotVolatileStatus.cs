using System.Collections;
using UnityEngine;

public class PostTurnDotVolatileStatus : PostTurnVolatileStatus
{
    public int Duration = -1;
    public int Index = 0;
    
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        Debug.Log($"Executed!");
        
        if (Duration == -1) Duration = Random.Range(2, 6);
        else
        {
            Index++;
            if (Index >= Duration) yield return OnRemove(manager, pokemon);
            else
            {
                yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.PokemonData.Name} was hurt!");
                yield return Particle.PlayParticle(pokemon.transform.position);
                yield return Damager.DamagePercentage(pokemon, 12.5f);
            }
        }
    }

    public override IEnumerator OnRemove(StatusManager manager, Pokemon pokemon)
    {
        pokemon.statuses.Remove(this);
        yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.PokemonData.Name} is no longer affected by the damaging effect!");
    }
}