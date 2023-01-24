using System.Collections;

public class DamageBlock : MoveBlock
{
    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return BattleTween.DealDamage(moveData, caster, afflictedPokemon);
    }
}

