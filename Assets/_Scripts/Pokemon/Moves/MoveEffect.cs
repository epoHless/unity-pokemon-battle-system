using UnityEngine;

[System.Serializable]
public class MoveEffect
{
    public virtual void Execute(Move move, Pokemon afflictedPokemon)
    {
        MobileFramework.Analytics.Logging.Message($"Move {GetType()} has been used on {afflictedPokemon.name}", Color.green, true);
        move.spawnedParticle.PlayParticle();
    }
}