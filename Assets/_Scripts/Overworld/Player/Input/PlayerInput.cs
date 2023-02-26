using UnityEngine;

public static class PlayerInput
{
    public static Vector2 GetAxis()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
}
