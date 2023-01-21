using System.Collections;
using UnityEngine;

public class ThunderPunch : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo,Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return moveSo.spawnedParticle.PlayParticle(afflictedPokemon.transform.position + Vector3.up * 0.5f);
        
        yield return BattleTween.DealDamage(moveSo, caster,afflictedPokemon);

        if (!afflictedPokemon.IsFainted)
        {
            bool paralyse = Random.Range(0, 100) < 10;
            if (paralyse) yield return StatusManager.Instance.ApplyParalyse(afflictedPokemon);
        }
    }
}