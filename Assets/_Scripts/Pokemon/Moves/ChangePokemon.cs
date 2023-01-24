using System.Collections;

public class ChangePokemon : MoveEffect
{
    public override IEnumerator Execute(MoveSO moveSo,Pokemon caster, Pokemon afflictedPokemon)
    {
        StatusManager.Instance.RemoveVolatileStatuses(caster);
        yield return BattleManager.Instance.ChangePokemon(caster, PokemonBagManager.Instance.team);
    }
}