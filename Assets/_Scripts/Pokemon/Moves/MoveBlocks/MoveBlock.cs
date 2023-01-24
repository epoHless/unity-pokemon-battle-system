using System.Collections;

[System.Serializable]
public class MoveBlock
{
    public virtual IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        yield return null;
    }
}

