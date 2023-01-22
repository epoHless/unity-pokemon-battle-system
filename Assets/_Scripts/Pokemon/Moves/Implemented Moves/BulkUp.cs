using System.Collections;
using UnityEngine;

public class BulkUp : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo,Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return moveSo.spawnedParticle.PlayParticle(afflictedPokemon.transform.position + Vector3.up * 0.5f);
        
        yield return afflictedPokemon.battleStats.ATK.IncreaseStat(afflictedPokemon, "Atk");
        yield return afflictedPokemon.battleStats.DEF.IncreaseStat(afflictedPokemon, "Def");
    }
}