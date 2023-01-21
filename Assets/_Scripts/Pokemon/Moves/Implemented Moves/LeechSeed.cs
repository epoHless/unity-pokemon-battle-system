using System.Collections;
using UnityEngine;

public class LeechSeed : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo,Pokemon caster, Pokemon afflictedPokemon)
    {
        if (StatusManager.Instance.IsSeeded(afflictedPokemon))
        {
            yield return NotificationManager.Instance.ShowNotificationCOR("But the move failed.", 1);
        }
        else
        {
            yield return moveSo.spawnedParticle.PlayParticle(afflictedPokemon.transform.position + Vector3.up * 0.5f);
        
            yield return StatusManager.Instance.ApplySeed(afflictedPokemon);
        }
    }
}