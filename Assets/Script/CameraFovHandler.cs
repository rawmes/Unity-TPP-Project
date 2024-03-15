using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraFovHandler : MonoBehaviour
{
    const float MAGIC_NUMBER = 0.005f;
    public int maxFov, minFov;
    [SerializeField]
    CinemachineFreeLook virtualCamera;
    float cameraFov=0;

    [SerializeField] float sensitiviy=1f;
    

     
    public void OnMouseScroll(InputAction.CallbackContext context)
    {
        if(cameraFov ==0) { cameraFov = virtualCamera.m_Lens.FieldOfView; }
        float val = context.ReadValue<Vector2>().y*-sensitiviy*MAGIC_NUMBER;

        //if (val == 0) return;

        cameraFov = MinMax(cameraFov+val);
        
        virtualCamera.m_Lens.FieldOfView = cameraFov;
       

        
        
    }
    public float MinMax(float value)
    {
        value = Math.Max(value, minFov);
        value = Math.Min(value, maxFov);

        return value;
    }
}
