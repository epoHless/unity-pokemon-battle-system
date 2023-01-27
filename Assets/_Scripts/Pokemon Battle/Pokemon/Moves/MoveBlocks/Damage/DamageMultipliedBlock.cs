using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Enumerable = System.Linq.Enumerable;

public class DamageMultipliedBlock : MoveBlock
{
    public bool IsCasterTargetOfCheck = true;
    [Range(1, 10)] public float Multiplier = 1f;
    public List<StatusInfo> StatusesToCheck;

    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        var tempMove = moveData;

        var target = IsCasterTargetOfCheck ? caster : afflictedPokemon;
        
        bool hasMatch = target.statuses.Any(x => StatusesToCheck.Any(y => y.status.GetType() == x.GetType()));
        
        if (hasMatch)
        {
            tempMove.MultiplyPower(Multiplier);
        }
        
        yield return Damager.Damage(tempMove, caster, afflictedPokemon);
    }
}