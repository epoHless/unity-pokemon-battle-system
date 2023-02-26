using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField, Range(1, 10f)] private float speed = 4f;
    [SerializeField] private LayerMask TileCollision;
    
    [Header("State Management")]
    [SerializeField] MovementState currentState;

    #region Private Settings

    private float movementDistance = 1;

    private Vector3 _targetPosition;
    public Vector3 TargetPosition
    {
        get => _targetPosition;

        set => _targetPosition = value;
    }

    Direction direction;

    public enum Direction
    {
        up, down, left, right
    }

    bool HasCollided
    {
        get
        {
            RaycastHit2D rh;

            Vector2 dir = Vector2.zero;

            if (direction == Direction.down)
                dir = Vector2.down;

            if (direction == Direction.left)
                dir = Vector2.left;

            if (direction == Direction.right)
                dir = Vector2.right;

            if (direction == Direction.up)
                dir = Vector2.up;

            rh = Physics2D.Raycast(transform.position, dir, movementDistance, TileCollision);

            if (rh.collider != null && rh.transform.gameObject.layer == 7 && transform.CollisionDirection(rh.transform, Vector2.down))
            {
                TargetPosition = transform.position + Vector3.down;
                MoveCharacter(speed);
            }
            
            return rh.collider != null && rh.transform.gameObject.layer != 7;
        }
    }

    #endregion

    private void Awake()
    {
        TargetPosition = transform.position;
    }

    private void Start()
    {
        currentState.OnEnter(this);
    }

    private void Update()
    {
        currentState.OnUpdate(this);
    }

    public void SetPosition(Vector2 _axisDirection, float _distance)
    {
        if (_axisDirection != Vector2.zero && TargetPosition == transform.position)
        {
            if(Mathf.Abs(_axisDirection.x) > Mathf.Abs(_axisDirection.y))
            {
                if(_axisDirection.x > 0)
                {
                    direction = Direction.right;
                    if(!HasCollided) TargetPosition += Vector3.right * _distance;
                }
                else
                {
                    direction = Direction.left;
                    if(!HasCollided) TargetPosition += Vector3.left * _distance;
                }
            }
            else
            {
                if (_axisDirection.y > 0)
                {
                    direction = Direction.up;
                    if(!HasCollided) TargetPosition += Vector3.up * _distance;
                }
                else
                {
                    direction = Direction.down;
                    if(!HasCollided) TargetPosition += Vector3.down * _distance;
                }
            }
            
            MoveCharacter(speed);
        }
    }

    public void MoveCharacter(float _speed)
    {
        LeanTween.move(gameObject, TargetPosition, 1 / _speed);
    }

    public void ChangeState(MovementState _newState)
    {
        currentState.OnExit(this);
        currentState = _newState;
        currentState.OnEnter(this);
    }
}

