using System.Collections;
using UnityEngine;

public class DamageAndRecoilBlock : MoveBlock
{
    [Range(0, 1)] public float PercentageRecoil;
    
    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return Damager.DamageAndRecoil(moveData, caster, afflictedPokemon, PercentageRecoil);
    }
}