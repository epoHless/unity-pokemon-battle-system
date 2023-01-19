using MobileFramework.Subclass;
using UnityEngine;

[System.Serializable]
public class StatusInfo
{
    public MoveParticle Particle;
    public Sprite Sprite;

    [SubclassOf(typeof(NonVolatileStatus))]
    public int Status;

    public Status status;

    public StatusInfo()
    {
        status = SubclassUtility.GetSubclassFromIndex<Status>(Status);
    }
}