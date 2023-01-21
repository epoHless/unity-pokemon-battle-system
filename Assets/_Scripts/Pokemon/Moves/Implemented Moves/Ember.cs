using System.Collections;
using UnityEngine;

public class Ember : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo,Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return moveSo.spawnedParticle.PlayParticle(afflictedPokemon.transform.position + Vector3.up * 0.5f);
        // yield return new WaitUntil(() => moveSo.spawnedParticle.IsDone);
        
        yield return BattleTween.DealDamage(moveSo, caster,afflictedPokemon);

        if (!afflictedPokemon.IsFainted)
        {
            bool burn = Random.Range(0, 100) < 10;
            if (burn) yield return StatusManager.Instance.ApplyBurn(afflictedPokemon);
        }
    }
}