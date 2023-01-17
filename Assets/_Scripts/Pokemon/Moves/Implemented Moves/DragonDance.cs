using UnityEngine;

public class DragonDance : MoveEffect
{
    public override bool Execute(Move move, Pokemon afflictedPokemon)
    {
        MobileFramework.Analytics.Logging.Message($"Move {GetType()} has been used on {afflictedPokemon.name}", Color.green, true);

        afflictedPokemon.battleStats.ATK.IncreaseStat();
        afflictedPokemon.battleStats.SPD.IncreaseStat();
        
        return true;
    }
}