using System.Collections;
using UnityEngine;

public class ShadowBall : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo, Pokemon afflictedPokemon)
    {
        MobileFramework.Analytics.Logging.Message($"Move {GetType()} has been used on {afflictedPokemon.name}", Color.green, true);
        moveSo.spawnedParticle.PlayParticle();

        moveSo.spawnedParticle.SetAction(() =>
        {
            BattleTween.DealDamage(moveSo, afflictedPokemon);
            afflictedPokemon.battleStats.SPDEF.DecreaseStat(afflictedPokemon);
            // ADD SCREEN NOTIFICATION
        });
        
        yield return new WaitUntil(() => moveSo.spawnedParticle.IsDone);
    }
}