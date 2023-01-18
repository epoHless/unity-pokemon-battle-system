using System.Collections;
using UnityEngine;

[System.Serializable]
public class MoveEffect
{
    public virtual IEnumerator Execute(MoveSO moveSo, Pokemon afflictedPokemon)
    {
        yield return null;
        MobileFramework.Analytics.Logging.Message($"Move {GetType()} has been used on {afflictedPokemon.name}", Color.green, true);
        moveSo.spawnedParticle.PlayParticle();
    }
}