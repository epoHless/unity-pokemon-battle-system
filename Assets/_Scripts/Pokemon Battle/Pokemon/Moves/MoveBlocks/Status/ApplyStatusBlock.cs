using System.Collections;

public class ApplyStatusBlock : MoveBlock
{
    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        return base.Execute(moveData, caster, afflictedPokemon);
    }
}