using System.Collections;
using UnityEngine;

public class DragonDance : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo, Pokemon afflictedPokemon)
    {
        MobileFramework.Analytics.Logging.Message($"Move {GetType()} has been used on {afflictedPokemon.name}", Color.green, true);
        moveSo.spawnedParticle.PlayParticle();

        yield return new WaitUntil(() => moveSo.spawnedParticle.IsDone);
        yield return afflictedPokemon.battleStats.ATK.IncreaseStat(afflictedPokemon);
        yield return new WaitUntil(() => NotificationManager.IsDone);
        yield return afflictedPokemon.battleStats.SPD.IncreaseStat(afflictedPokemon);
    }
}