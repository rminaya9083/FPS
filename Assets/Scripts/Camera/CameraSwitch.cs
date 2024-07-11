using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{

    public Camera thirdPersonCamera;

    public Camera mainCamera;

    private bool mainCameraEnabled = true;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            mainCameraEnabled = !mainCameraEnabled;
            ChangeCamera();
        }
    }

    public void ChangeCamera()
    {
        if (mainCameraEnabled)
        {
            mainCamera.enabled = true;
            thirdPersonCamera.enabled = false;
        }
        else
        {
            mainCamera.enabled = false;
            thirdPersonCamera.enabled = true;
        }
    }

}
