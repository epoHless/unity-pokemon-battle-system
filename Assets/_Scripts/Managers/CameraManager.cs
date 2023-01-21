using Cinemachine;
using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    public CinemachineVirtualCamera moveUsedCamera;
    public CinemachineVirtualCamera moveSelectionCamera;

    public void UseMoveCamera(Transform lookAt)
    {
        moveSelectionCamera.Priority = 0;
        moveUsedCamera.Priority = 1;
        moveUsedCamera.LookAt = lookAt;
    }
    
    public void UseSelectionCamera()
    {
        moveUsedCamera.Priority = 0;
        moveSelectionCamera.Priority = 1;
    }
}