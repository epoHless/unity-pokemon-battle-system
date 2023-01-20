using System.Collections;
using UnityEngine;

public class FreezedStatus : PreTurnNonVolatileStatus
{
    public override IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        bool BreakeFree = Random.Range(0, 100) <= 20;

        if (!BreakeFree)
        {
            yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} is frozen solid and unable to move!");
            manager.GetStatusParticle(manager.FrozenStatus).PlayParticle(pokemon.transform.position);
            yield return new WaitUntil(() => manager.FrozenStatus.Particle.IsDone);
            pokemon.CanAttack = false;
        }
        else
        {
            yield return OnRemove(manager, pokemon);
        }
    }

    public override IEnumerator OnRemove(StatusManager manager, Pokemon pokemon)
    {
        pokemon.CanAttack = true;
        pokemon.statuses.Remove(this);
        pokemon.ui.RemoveStateIcon();
        yield return NotificationManager.Instance.ShowNotificationCOR($"{pokemon.Name} broke trough the ice!");
    }
}