using System.Collections;
using UnityEngine;

public class ShadowBall : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo, Pokemon afflictedPokemon)
    {
        moveSo.spawnedParticle.PlayParticle();

        moveSo.spawnedParticle.SetAction(() =>
        {
            BattleTween.DealDamage(moveSo, afflictedPokemon);
        });
        
        yield return new WaitUntil(() => moveSo.spawnedParticle.IsDone);
        yield return afflictedPokemon.battleStats.SPDEF.DecreaseStat(afflictedPokemon, "Sp.Def.");
    }
}