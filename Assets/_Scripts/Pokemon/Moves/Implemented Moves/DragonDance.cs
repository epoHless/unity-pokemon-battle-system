using System.Collections;
using UnityEngine;

public class DragonDance : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo, Pokemon afflictedPokemon)
    {
        MobileFramework.Analytics.Logging.Message($"Move {GetType()} has been used on {afflictedPokemon.name}", Color.green, true);
        moveSo.spawnedParticle.PlayParticle();

        moveSo.spawnedParticle.SetAction(() =>
        {
            afflictedPokemon.battleStats.ATK.IncreaseStat();
            afflictedPokemon.battleStats.SPD.IncreaseStat();
            // ADD SCREEN NOTIFICATION
        });

        yield return new WaitUntil(() => moveSo.spawnedParticle.IsDone);
    }
}