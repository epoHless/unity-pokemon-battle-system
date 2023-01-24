
using System.Collections;

public class DamageAndHealBlock : MoveBlock
{
    public float PercentageHeal;
    
    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return BattleTween.DamageAndHealPokemon(afflictedPokemon, PercentageHeal);
    }
}