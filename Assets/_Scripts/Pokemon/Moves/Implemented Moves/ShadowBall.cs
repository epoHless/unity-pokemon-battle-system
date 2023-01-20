using System.Collections;
using UnityEngine;

public class ShadowBall : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo,Pokemon caster, Pokemon afflictedPokemon)
    {
        moveSo.spawnedParticle.PlayParticle(afflictedPokemon.transform.position);
        yield return new WaitUntil(() => moveSo.spawnedParticle.IsDone);
        
        yield return BattleTween.DealDamage(moveSo, caster,afflictedPokemon);
        
        if (!afflictedPokemon.IsFainted)
        {
            yield return afflictedPokemon.battleStats.SPDEF.DecreaseStat(afflictedPokemon, "Sp.Def.");
        }
    }
}