
    using System.Collections;
    using UnityEngine;

    public class Facade : MoveEffect
    {
        public override IEnumerator Execute(MoveSO moveSo,Pokemon caster, Pokemon afflictedPokemon)
        {
            moveSo.spawnedParticle.PlayParticle(afflictedPokemon.transform.position + Vector3.up * 0.5f);
            yield return new WaitUntil(() => moveSo.spawnedParticle.IsDone);

            if (StatusManager.Instance.IsBurned(afflictedPokemon) || StatusManager.Instance.IsPoisoned(afflictedPokemon) || StatusManager.Instance.IsParalysed(afflictedPokemon) )
            {
                yield return BattleTween.DealDamageIncreased(moveSo, caster,afflictedPokemon, 2);
            }
            else
            {
                yield return BattleTween.DealDamage(moveSo, caster,afflictedPokemon);
            }
        }
    }

