using UnityEngine;

[System.Serializable]
public class MoveEffect
{
    public virtual void Execute(MoveSO moveSo, Pokemon afflictedPokemon)
    {
        MobileFramework.Analytics.Logging.Message($"Move {GetType()} has been used on {afflictedPokemon.name}", Color.green, true);
        moveSo.spawnedParticle.PlayParticle();
    }
}