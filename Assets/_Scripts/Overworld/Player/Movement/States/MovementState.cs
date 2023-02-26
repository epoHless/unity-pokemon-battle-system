using UnityEngine;

public abstract class MovementState : ScriptableObject
{
    public virtual void OnEnter(PlayerMovement _movement){ Debug.Log($"Entering {GetType()}"); }
    public virtual void OnUpdate(PlayerMovement _movement){}
    public virtual void OnExit(PlayerMovement _movement){ Debug.Log($"Exiting {GetType()}"); }
}
