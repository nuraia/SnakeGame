using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cineMachineVirtualCamera;
    private float ShakeIntensity = 3.0f;
    private float ShakeTime = 0.2f;

    public float timer = 1;
    private CinemachineBasicMultiChannelPerlin _cbmcp;
    void Awake()
    {
        cineMachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {
        StopShake();
    }
   public void ShakeCamera()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = cineMachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = ShakeIntensity;
        timer = ShakeTime;
    }
    public void StopShake()
    {
        CinemachineBasicMultiChannelPerlin _cbmcp = cineMachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cbmcp.m_AmplitudeGain = 0;
        timer = 0;
    }

}
