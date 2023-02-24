using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class RotateUser : MonoBehaviour
{
    public ARCameraManager arCameraManager;

    // Update is called once per frame
    void Update()
    {
        Transform cameraTransform = arCameraManager.GetComponent<Camera>().transform;
        Quaternion yRotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0f);
        transform.rotation = yRotation;
    }
}
