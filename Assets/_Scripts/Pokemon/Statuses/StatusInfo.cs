using System.Collections;
using System.Collections.Generic;
using MobileFramework.Subclass;
using UnityEngine;

[CreateAssetMenu(fileName = "Status_", menuName = "Pokemon/New Status", order = 0)]
public class StatusInfo : ScriptableObject
{
    public string Name;
    public MoveParticle Particle;
    public Sprite Sprite;
    public string Message;

    [SubclassOf(typeof(Status))]
    public int Status;
    public Status status;

    [SerializeReference] public List<ApplyStatusBlock> statusBlocks;
    
    public virtual IEnumerator Execute(StatusManager manager, Pokemon pokemon)
    {
        yield return null;
    }

    public virtual IEnumerator OnRemove(StatusManager manager, Pokemon pokemon)
    {
        yield return null;
    }
}