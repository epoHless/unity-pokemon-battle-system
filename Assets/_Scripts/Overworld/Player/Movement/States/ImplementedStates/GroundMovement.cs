using UnityEngine;

[CreateAssetMenu(fileName = "Movement_", menuName = "States/Movement/New Ground Movement", order = 0)]
public class GroundMovement : MovementState
{
    [SerializeField] private AnimatorOverrideController animator;
    
    public override void OnEnter(PlayerMovement _movement)
    {
        base.OnEnter(_movement);
    }

    public override void OnUpdate(PlayerMovement _movement)
    {
        base.OnUpdate(_movement);
        
        _movement.SetPosition(PlayerInput.GetAxis(),1);
    }

    public override void OnExit(PlayerMovement _movement)
    {
        base.OnExit(_movement);
    }
}
