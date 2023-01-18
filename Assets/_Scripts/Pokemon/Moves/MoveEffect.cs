using UnityEngine;

[System.Serializable]
public class MoveEffect
{
    public virtual bool Execute(Move move, Pokemon afflictedPokemon)
    {
        return false;
    }
}