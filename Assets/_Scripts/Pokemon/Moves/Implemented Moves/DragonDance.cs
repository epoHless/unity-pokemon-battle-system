using System.Collections;
using UnityEngine;

public class DragonDance : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo, Pokemon caster, Pokemon afflictedPokemon)
    {
        moveSo.spawnedParticle.PlayParticle(afflictedPokemon.transform.position);

        yield return new WaitUntil(() => moveSo.spawnedParticle.IsDone);
        yield return afflictedPokemon.battleStats.ATK.IncreaseStat(afflictedPokemon, "Atk");
        yield return new WaitUntil(() => NotificationManager.IsDone);
        yield return afflictedPokemon.battleStats.SPD.IncreaseStat(afflictedPokemon, "Spd");
    }
}