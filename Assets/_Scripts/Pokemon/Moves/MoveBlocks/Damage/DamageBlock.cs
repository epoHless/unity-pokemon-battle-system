using System.Collections;
using System.Collections.Generic;

public class DamageBlock : MoveBlock
{
    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return BattleTween.DealDamage(moveData, caster, afflictedPokemon);
    }
}

