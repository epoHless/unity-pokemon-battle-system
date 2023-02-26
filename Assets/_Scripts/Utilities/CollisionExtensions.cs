using UnityEngine;

public static class CollisionExtensions
{
    public static bool CollisionDirection(this Transform _transform, Transform _other, Vector2 _direction)
    {
        Vector2 direction = _other.position - _transform.position;
        return Vector2.Dot(direction.normalized, _direction) > 0.25f;
    }
}
