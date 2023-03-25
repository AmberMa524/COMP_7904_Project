using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_StealMainCamera : MonoBehaviour
{
    public bool isStartingCamera = false;
    static Camera currentCamera;
    public Camera cam;
    public AT_StealCameraTrigger triggerA;
    public AT_StealCameraTrigger triggerB;

    private void Awake()
    {
        if(isStartingCamera)
        {
            currentCamera = cam;
        } else
        {
            cam.enabled = false;
        }

        triggerA.steal = StealCamera;
        triggerB.steal = StealCamera;
    }

    public void StealCamera(Collider other)
    {
        if(other.tag == "Player")
        {
            StealCamera();
        }
    }

    public void StealCamera()
    {
        currentCamera.enabled = false;
        cam.enabled = true;
        currentCamera = cam;
    }
}
