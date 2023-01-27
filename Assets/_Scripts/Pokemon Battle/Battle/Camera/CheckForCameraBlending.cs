using System.Collections;
using Cinemachine;
using UnityEngine;

public class CheckForCameraBlending : Singleton<CheckForCameraBlending>
{
    public delegate void CameraBlendStarted();
    public static event CameraBlendStarted onCameraBlendStarted;
    
    public delegate void CameraBlendFinished();
    public static event CameraBlendFinished onCameraBlendFinished;
 
    private CinemachineBrain cineMachineBrain;
 
    private bool wasBlendingLastFrame;

    protected override void Awake()
    {
        base.Awake();
        
        cineMachineBrain = GetComponent<CinemachineBrain>();
    }
    
    void Start()
    {
        wasBlendingLastFrame = false;
    }
    
    void Update()
    {
        if (cineMachineBrain.IsBlending)
        {
            if (!wasBlendingLastFrame)
            {
                if (onCameraBlendStarted != null)
                {
                    onCameraBlendStarted();
                }
            }
    
            wasBlendingLastFrame = true;
        }
        else
        {
            if (wasBlendingLastFrame)
            {
                if (onCameraBlendFinished != null)
                {
                    onCameraBlendFinished();
                }
                wasBlendingLastFrame = false;
            }
        }
    }

    public IEnumerator WaitForBlend()
    {
        yield return new WaitUntil(() => cineMachineBrain.IsBlending);
    }
}