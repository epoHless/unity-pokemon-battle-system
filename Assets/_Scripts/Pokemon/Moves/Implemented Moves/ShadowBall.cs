using UnityEngine;

public class ShadowBall : MoveEffect
{
    public override void Execute(MoveSO moveSo, Pokemon afflictedPokemon)
    {
        base.Execute(moveSo,afflictedPokemon);
        
        moveSo.spawnedParticle.SetAction(() =>
        {
            BattleTween.DealDamage(moveSo, afflictedPokemon);

            // ADD SCREEN NOTIFICATION
        });
    }
}