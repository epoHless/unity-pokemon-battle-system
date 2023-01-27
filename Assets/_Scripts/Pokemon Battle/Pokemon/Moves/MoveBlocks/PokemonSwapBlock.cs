using System.Collections;

public class PokemonSwapBlock : MoveBlock
{
    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return BattleManager.Instance.ChangePokemon(caster, PokemonBagManager.Instance.team);
    }
}