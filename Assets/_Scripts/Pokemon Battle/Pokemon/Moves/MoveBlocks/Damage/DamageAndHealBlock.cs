
using System.Collections;
using UnityEngine;

public class DamageAndHealBlock : MoveBlock
{
    [Range(0, 1)] public float PercentageHeal;
    
    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return Damager.DamageAndLeech(moveData, caster, afflictedPokemon, PercentageHeal);
    }
}