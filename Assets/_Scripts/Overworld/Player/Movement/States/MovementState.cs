using UnityEngine;

public abstract class MovementState : ScriptableObject
{
    [SerializeField, Range(1, 10)] protected float speed;
    [SerializeField] protected AnimatorOverrideController animator;

    public virtual void OnEnter(PlayerMovement _movement)
    {
        Debug.Log($"Entering {GetType()}");
        
        _movement.Controller.OverrideAnimator(animator);
        _movement.SetSpeed(speed);
    }
    
    public virtual void OnUpdate(PlayerMovement _movement){}
    public virtual void OnExit(PlayerMovement _movement){ Debug.Log($"Exiting {GetType()}"); }
}
