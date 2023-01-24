using MobileFramework.Subclass;
using UnityEngine;

[System.Serializable]
public class StatusInfo
{
    public string Name;
    public MoveParticle Particle;
    public Sprite Sprite;
    public string Message;

    [SubclassOf(typeof(Status))]
    public int Status;

    public Status status;
}