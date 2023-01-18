﻿using UnityEngine;

public class DragonDance : MoveEffect
{
    public override bool Execute(Move move, Pokemon afflictedPokemon)
    {
        MobileFramework.Analytics.Logging.Message($"Move {GetType()} has been used on {afflictedPokemon.name}", Color.green, true);

        move.spawnedParticle.PlayParticle();
        
        move.spawnedParticle.SetAction(() =>
        {
            afflictedPokemon.battleStats.ATK.IncreaseStat();
            afflictedPokemon.battleStats.SPD.IncreaseStat();
            
            // ADD SCREEN NOTIFICATION
        });

        return true;
    }
}