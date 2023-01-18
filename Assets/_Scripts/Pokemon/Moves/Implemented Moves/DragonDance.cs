using UnityEngine;

public class DragonDance : MoveEffect
{
    public override void Execute(Move move, Pokemon afflictedPokemon)
    {
        base.Execute(move,afflictedPokemon);

        move.spawnedParticle.SetAction(() =>
        {
            afflictedPokemon.battleStats.ATK.IncreaseStat();
            afflictedPokemon.battleStats.SPD.IncreaseStat();
            
            // ADD SCREEN NOTIFICATION
        });
    }
}