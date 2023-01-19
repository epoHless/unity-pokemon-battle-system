using UnityEngine;

public class StatusManager : Singleton<StatusManager>
{
    [field: SerializeField] public StatusInfo BurnStatus;
    private MoveParticle spawnedBurnParticle;
    
    public void AddPostTurnNonVolatileStatus(Pokemon pokemon, PostTurnNonVolatileStatus status)
    {
        if (!pokemon.statuses.Contains(status))
        {
            pokemon.statuses.Add(status);
        }
    }

    public MoveParticle GetBurnParticle()
    {
        if (spawnedBurnParticle)
        {
            return spawnedBurnParticle;
        }
        else
        {
            spawnedBurnParticle = Instantiate(BurnStatus.Particle);
            return spawnedBurnParticle;
        }
    }
}

