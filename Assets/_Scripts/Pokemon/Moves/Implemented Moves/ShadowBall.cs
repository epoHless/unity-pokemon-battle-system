using UnityEngine;

public class ShadowBall : MoveEffect
{
    public override bool Execute(Move move, Pokemon afflictedPokemon)
    {
        MobileFramework.Analytics.Logging.Message($"Move {GetType()} has been used on {afflictedPokemon.name}", Color.green, true);
       
        return true;
    }
}