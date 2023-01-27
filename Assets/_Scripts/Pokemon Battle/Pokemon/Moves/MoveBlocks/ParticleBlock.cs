using System.Collections;
using UnityEngine;

public class ParticleBlock : MoveBlock
{
    public MoveParticle Particle;
    public Vector3 offset;

    private MoveParticle spawnedParticle;
    
    public override IEnumerator Execute(MoveSO moveData, Pokemon caster, Pokemon afflictedPokemon)
    {
        if (!spawnedParticle) spawnedParticle = GameObject.Instantiate(Particle);
        yield return spawnedParticle.PlayParticle(afflictedPokemon.transform.position + offset);
    }
}