using UnityEngine;

public class ShadowBall : MoveEffect
{
    public override void Execute(Move move, Pokemon afflictedPokemon)
    {
        base.Execute(move,afflictedPokemon);
        
        move.spawnedParticle.SetAction(() =>
        {
            BattleTween.DealDamage(move, afflictedPokemon);

            // ADD SCREEN NOTIFICATION
        });
    }
}