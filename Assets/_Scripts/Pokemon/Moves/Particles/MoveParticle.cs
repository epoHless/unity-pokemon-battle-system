using System;
using System.Collections;
using UnityEngine;

public class MoveParticle : MonoBehaviour
{
    private new ParticleSystem particleSystem;
    private ParticleSystem.MainModule main;

    private Action particleAction;

    [field: SerializeField] public bool IsDone { get; private set; }
    
    protected virtual void Awake()
    {
        particleSystem = GetComponent<ParticleSystem>();
        main = particleSystem.main;
    }

    protected virtual void OnEnable()
    {
        IsDone = false;
        main.stopAction = ParticleSystemStopAction.Callback;
    }

    protected virtual void OnDisable()
    {
        main.stopAction = ParticleSystemStopAction.None;
    }

    private void OnParticleSystemStopped()
    {
        IsDone = true;
        particleAction?.Invoke();
        gameObject.SetActive(false);
    }

    public void PlayParticle(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }

    public void SetAction(Action action)
    {
        particleAction = action;
    }
}