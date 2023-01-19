using System.Collections;
using UnityEngine;

public class ShadowBall : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo,Pokemon caster, Pokemon afflictedPokemon)
    {
        moveSo.spawnedParticle.PlayParticle(afflictedPokemon.transform.position);

        moveSo.spawnedParticle.SetAction(() =>
        {
            BattleTween.DealDamage(moveSo, caster,afflictedPokemon);
        });
        
        yield return new WaitUntil(() => moveSo.spawnedParticle.IsDone);
        yield return StatusManager.Instance.ApplyFreeze(afflictedPokemon);
        yield return afflictedPokemon.battleStats.SPDEF.DecreaseStat(afflictedPokemon, "Sp.Def.");
    }
}