using UnityEngine;

[CreateAssetMenu(fileName = "Movement_", menuName = "States/Movement/New Running Movement", order = 0)]
public class RunningMovement : MovementState
{
    public override void OnEnter(PlayerMovement _movement)
    {
        base.OnEnter(_movement);
    }

    public override void OnUpdate(PlayerMovement _movement)
    {
        base.OnUpdate(_movement);
        
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _movement.ChangeState(_movement.WalkingState);
        }
        
        _movement.SetPosition(PlayerInput.GetAxis(),1);
    }

    public override void OnExit(PlayerMovement _movement)
    {
        base.OnExit(_movement);
    }
}
