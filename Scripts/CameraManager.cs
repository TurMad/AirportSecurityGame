using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera oldCamera;
    public CinemachineVirtualCamera newCamera;  

    private void Start()
    {
        oldCamera.m_Priority = 5;
        newCamera.m_Priority = 1;
    }
    private void OnTriggerEnter(Collider other)
    {
        oldCamera.m_Priority = 1;
        newCamera.m_Priority = 5;
    }
}
