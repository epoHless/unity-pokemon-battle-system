using System.Collections;

public class DamageAndRecoilBlock : MoveBlock
{
    public float PercentageRecoil;
    
    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return BattleTween.DamageAndHealPokemon(afflictedPokemon, PercentageRecoil);
    }
}