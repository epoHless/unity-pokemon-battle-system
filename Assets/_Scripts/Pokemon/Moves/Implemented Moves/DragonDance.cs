using UnityEngine;

public class DragonDance : MoveEffect
{
    public override void Execute(MoveSO moveSo, Pokemon afflictedPokemon)
    {
        base.Execute(moveSo,afflictedPokemon);

        moveSo.spawnedParticle.SetAction(() =>
        {
            afflictedPokemon.battleStats.ATK.IncreaseStat();
            afflictedPokemon.battleStats.SPD.IncreaseStat();
            
            // ADD SCREEN NOTIFICATION
        });
    }
}