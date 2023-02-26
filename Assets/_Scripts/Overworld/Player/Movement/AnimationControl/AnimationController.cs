using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    public Animator Animator { get; private set; }
    private PlayerMovement movement;
    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        PlayerMovement.OnMovementStarted += SetAnimationOnStart;
    }

    private void SetAnimationOnStart(Vector2 obj)
    {
        Animator.SetFloat("xDir", obj.x);
        Animator.SetFloat("yDir", obj.y);
        Animator.SetFloat("Speed", obj.magnitude);

        spriteRenderer.flipX = obj.x > 0;
    }

    public void OverrideAnimator(AnimatorOverrideController _animator)
    {
        Animator.runtimeAnimatorController = _animator;
    }

    public void SetMovement(PlayerMovement _movement)
    {
        movement = _movement;
    }
}
